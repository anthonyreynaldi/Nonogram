using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Poin : MonoBehaviour
{
    public TextMeshProUGUI textPoin;
    public float poin = 0;

    // Start is called before the first frame update
    void Start()
    {
        displayPoin(poin);
    }

    // Update is called once per frame
    void Update()
    {
        //test iniput
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            add(10);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            min(10);
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            multiply(10);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            div(10);
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            mod(10);
        }*/
    }

    void displayPoin(float poin)
    {
        textPoin.text = string.Format("Poin: {0:0}", Mathf.FloorToInt(poin));
    }

    public void add(float number)
    {
        poin += number;
        displayPoin(poin);
    }

    public void min(float number)
    {
        poin -= number;
        displayPoin(poin);
    }

    public void multiply(float number)
    {
        poin *= number;
        displayPoin(poin);
    }

    public void div(float number)
    {
        poin /= number;
        displayPoin(poin);
    }

    public void mod(float number)
    {
        poin %= number;
        displayPoin(poin);
    }
}
