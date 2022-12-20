using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Skip : MonoBehaviour
{
    public GridManager gm;
    public GameObject highlight;
    public TextMeshProUGUI textSkip;
    public bool pressed = false;
    private int diff;
    public Win winObj;
    public TimerManager timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<TimerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        pressed = Input.GetMouseButton(0);
        textSkip.text = string.Format("SKIP ({0})", Mathf.FloorToInt(winObj.numSkipRemain));
    }

    void OnMouseOver() {
        highlight.SetActive(true);
    }

    void OnMouseUp() {
        if (pressed && !timer.isFinish) {
            winObj.skip();
            /*gm.RefreshBoard();*/
        } 
    }

    void OnMouseExit() {
        highlight.SetActive(false);
    }
}
