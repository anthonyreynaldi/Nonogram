using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int diff = 5;
    public GameObject parent;
    private int rows;
    private int cols;
    private float tileSize = (float) 1.1;
    private const string PATH = "Assets/Questions";
    private const int EASY_SIZE = 5;
    private const int MEDIUM_SIZE = 10;
    private const int HARD_SIZE = 15;
    private BoardParse[] easyBoards;
    private BoardParse[] medBoards;
    private BoardParse[] hardBoards;
    private string [] easyQuestions = Directory.GetFiles(PATH + "/Easy", "*.json");
    private string [] mediumQuestions = Directory.GetFiles(PATH + "/Medium", "*.json");
    private string [] hardQuestions = Directory.GetFiles(PATH + "/Hard", "*.json");
    private List<string> usedQuestions;

    //board for check winner
    public GameObject winGameObj;
    Win winObj;

    void Awake()
    {
        winObj = winGameObj.GetComponent<Win>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateDiff(diff);
    }

    public void GenerateDiff(int diff)
    {
        switch (diff) {
            case MEDIUM_SIZE:
                rows = 16;
                cols = 16;
                Camera.main.orthographicSize = 10; 
                LoadQuestions("Medium");
                break; 
            case HARD_SIZE:
                rows = 24;
                cols = 24;
                Camera.main.orthographicSize = 12; 
                LoadQuestions("Hard");
                break;
            default:
                rows = 8;
                cols = 8;
                Camera.main.orthographicSize = 5;
                LoadQuestions("Easy");
                break;
        }
    }   

    public void LoadQuestions(string diff) {
        string[] path = {};
        if (diff == "Easy") {
            path = easyQuestions;
        } else if (diff == "Medium") {
            path = mediumQuestions;
        } else {
            path = hardQuestions;
        }

        var random = new System.Random();
        var list = new List<string>();

        foreach (string fileName in path) {
            list.Add(fileName);
        }

        int index = random.Next(list.Count);

        GameObject referenceTile = (GameObject)Instantiate(Resources.Load("Tile"));
        GameObject referenceQ = (GameObject)Instantiate(Resources.Load("Question"));

        string jsonFile = ReadFile(list[index]);
        Debug.Log(list[index]);
        BoardParse boardData = JsonConvert.DeserializeObject<BoardParse>(jsonFile);
        
        var ctrRow = 0;
        var ctrCol = 0;

        winObj.boardWin = new List<List<int>>();

        foreach (var row in boardData.board) {
            winObj.boardWin.Add(new List<int>());

            foreach (var col in row) {

                if (col.type == "tile") {
                    GameObject tile = (GameObject)Instantiate(referenceTile, transform);
                    winObj.boardWin[ctrRow].Add(0);

                    if (col.isFilled == true) {
                        tile.GetComponent<Tile>().SetClickable();
                        winObj.boardWin[ctrRow][ctrCol] = 1;
                    }
                    tile.name = $"T {ctrRow} {ctrCol}";
                    float posX = ctrCol * tileSize;
                    float posY = ctrRow * -tileSize;
                    tile.transform.localPosition = new Vector2(posX, posY);
                } else if (col.type == "text") {
                    GameObject tile = (GameObject)Instantiate(referenceQ, transform);
                    tile.name = $"Q {ctrRow} {ctrCol}";
                    tile.GetComponent<QuestionGenerator>().content = $"{col.value}";
                    float posX = ctrCol * tileSize;
                    float posY = ctrRow * -tileSize;
                    tile.transform.localPosition = new Vector2(posX, posY);
                }
                ctrCol += 1;
            }
            ctrCol = 0;
            ctrRow += 1;
        };

        Destroy(referenceTile);
        Destroy(referenceQ);

        float gridWidth = cols * tileSize;
        float gridHeight = rows * tileSize;
        //transform.localPosition = new Vector2(-gridWidth/2 + tileSize/2, gridHeight/2 - tileSize/2);

        gridWidth = diff=="Easy"? 5f : diff=="Medium" ? 10f : 15f;
        gridHeight = gridWidth;
        transform.localPosition = new Vector2(-gridWidth/2, gridHeight/2+1f);
    }

    public string ReadFile(string file) {
        return File.ReadAllText(file);
    }

    public int GetDiff() {
        return this.diff;
    }

    public void RefreshBoard() {
        while (parent.transform.childCount > 0) {
            DestroyImmediate(parent.transform.GetChild(0).gameObject);
        }

        GenerateDiff(this.diff);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

    public class BoardColor 
    {
        public int R;
        public int G;
        public int B;   
    }

    public class BoardQuestion
    {
        public string type;
        public bool isFilled;
        public BoardColor color;
        public string value;
    }

    public class BoardParse
    {
        public BoardQuestion[][] board;
        public int size;
    }
