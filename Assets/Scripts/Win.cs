using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public List<List<int>> boardWin = new List<List<int>>();
    public float poinPerWin = 10;
    public float poinPerWrong = 1;
    Poin poinObj;
    public GridManager gm;
    public int numWinStreakToUp = 2;
    public int numWrongToDown = 10;
    public int winStreak = 0;
    public int numWrong = 0;
    public int numSkipRemain = 0;
    public int maxSkip = 3;

    void Awake()
    {
        poinObj = GameObject.Find("Poin").GetComponent<Poin>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        numSkipRemain = maxSkip;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            string result = "";
            foreach (var item in boardWin)
            {
                foreach (var i in item)
                {
                    result += i.ToString() + ", ";
                }
                result += "\n";
            }
            Debug.Log(result);
        }
    }

    public int clicked(int row, int col, bool rightChoice)
    {
        Debug.Log(row + " " + col);
        
        if (boardWin[row][col] == 1 && rightChoice) {           //mencet yang item dan kondisi button holder true (mencet sesuai kondisi sekarang)
            boardWin[row][col] = -1;

            if (isWin())
            {
                Debug.Log("Menang");
                poinObj.add(poinPerWin);
                winStreak++;
                numWrong = 0;

                reloadBoard(true);
                return -1;
            }

        }
        else if(boardWin[row][col] == 0 && rightChoice)       //mencet yang silang dan kondisi button holder false
        {
            boardWin[row][col] = -1;
            
        }
        else if(boardWin[row][col] != -1 && !rightChoice) //salah mencet
        {
            poinObj.min(poinPerWrong);
            numWrong++;
            reloadBoard(false);
            return 0;
        }

        return boardWin[row][col];          //1 == filled, 0 == kosong, -1 == sudah diclick
    }

    public bool isWin()
    {
        for (int i = 0; i < boardWin.Count; i++)
        {
            for (int j = 0; j < boardWin[i].Count; j++)
            {
                if (boardWin[i][j] == 1)
                {
                    return false;
                }
            }
        }

        return true;
    }

    void reloadBoard(bool isWin)
    {
        if(winStreak >= numWinStreakToUp && isWin)           //kalo uda win streak difficultnya bertambah
        {
            if(gm.diff < 15)
            {
                gm.diff += 5;
                poinPerWin *= 2;
            }
            numSkipRemain = maxSkip;            //reset jumlah skip

            gm.RefreshBoard();
            return;
        }
        else if (isWin)
        {
            numSkipRemain = maxSkip;            //reset jumlah skip
            gm.RefreshBoard();
            return;
        }

        if(numWrong >= numWrongToDown && !isWin)
        {
            winStreak = 0;          //reset win streak
            numWrong = 0;
            numSkipRemain = maxSkip;
            if (gm.diff > 5)
            {
                gm.diff -= 5;
                poinPerWin /= 2;
            }
            gm.RefreshBoard();
            return;
        }
    }

    public void skip()
    {
        
        numWrong = 0;
        if (numSkipRemain > 0)
        {
            numSkipRemain--;
            Debug.Log("skip");
            gm.RefreshBoard();
            return;
        }
    }
}
