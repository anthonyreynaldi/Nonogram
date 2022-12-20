using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionGenerator : MonoBehaviour
{
    public GameObject TextGO;
    private TextMeshProUGUI qText;
    public string content;    

    void Start() {
        qText = TextGO.GetComponent<TextMeshProUGUI>();
        qText.SetText(content);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(qText);
    }
}
