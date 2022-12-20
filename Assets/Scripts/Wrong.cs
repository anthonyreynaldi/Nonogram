using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wrong : MonoBehaviour
{
    public TextMeshProUGUI textWrong;
    public Win winObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textWrong.text = string.Format("Missed: {0}", Mathf.FloorToInt(winObj.numWrong));
    }
}
