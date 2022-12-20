using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject highlight;
    public GameObject color;
    public GameObject barrier;
    public GameObject error;
    public GameObject curr;
    public GameObject other;
    public bool pressed = false;
    public bool isFilled = false;
    public ButtonHolder buttonHolder;
    public int R;
    public int G;
    public int B;

    public GameObject winGameObj;
    Win winObj;
    public TimerManager timer;

    void Awake()
    {
        winGameObj = GameObject.Find("Win");
        winObj = winGameObj.GetComponent<Win>();
        timer = GameObject.Find("Timer").GetComponent<TimerManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        curr = color;
        other = barrier;
        buttonHolder = GameObject.Find("ButtonHolder").GetComponent<ButtonHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        /*pressed = Input.GetMouseButton(0);*/
        if (buttonHolder.isFill)
        {
            curr = color;
            other = barrier;
        }
        else
        {
            curr = barrier;
            other = color;
        }
        /*curr = color;
        other = barrier;*/
    }

    public void SetRGB(int r, int g, int b) {
        R = r;
        G = g;
        B = b;
    }

    public void SetClickable() {
        isFilled = true;
    }

    void OnMouseOver() {
        if (!pressed && curr.activeInHierarchy == false && other.activeInHierarchy == false)
        {
            highlight.SetActive(true);


        }
        else if (pressed && isFilled == true && curr == color)
        {      //tile yang bener

            curr.SetActive(true);

            //get row and col that clicked
            string[] name = this.name.Split(null);
            int row = int.Parse(name[1]);
            int col = int.Parse(name[2]);

            //set clicked
            winObj.clicked(row, col, true);

            pressed = false;

        }
        else if (pressed && isFilled == false && curr == barrier)
        {   //tile yang salah

            curr.SetActive(true);

            //get row and col that clicked
            string[] name = this.name.Split(null);
            int row = int.Parse(name[1]);
            int col = int.Parse(name[2]);

            //set clicked
            winObj.clicked(row, col, true);

            pressed = false;

        }
        else if (pressed && isFilled == true && curr != color)          //salah milih silang (harusnya item)
        {

            //get row and col that clicked
            string[] name = this.name.Split(null);
            int row = int.Parse(name[1]);
            int col = int.Parse(name[2]);

            //set clicked
            if (winObj.clicked(row, col, false) != -1)
            {
                if (error != null)
                {
                    StartCoroutine(Error());
                }
            }

            pressed = false;
        }
        else if (pressed && isFilled == false && curr != barrier)       //salah milih item (harusnya silang)
        {
            
            //get row and col that clicked
            string[] name = this.name.Split(null);
            int row = int.Parse(name[1]);
            int col = int.Parse(name[2]);

            //set clicked
            if(winObj.clicked(row, col, false) != -1)
            {
                if(error != null)
                {
                    StartCoroutine(Error());
                }
            }

            pressed = false;
        }

            // } else if (pressed && other.activeInHierarchy == false) {
            //     curr.SetActive(true);
            //     highlight.SetActive(false);
            // }
    }

    void OnMouseExit() {
        highlight.SetActive(false);
        pressed = false;
    }

    void OnMouseUp()
    {
        if (!timer.isFinish)        //selama waktu belum habis bisa diclick
        {
            pressed = true;
        }
    }

    IEnumerator Error()
    {
        for(int i = 0; i < 3; i++)
        {
            if(error != null)
            {
                error.SetActive(true);
                yield return new WaitForSeconds(0.2f);
                error.SetActive(false);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
