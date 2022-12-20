using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneGame : MonoBehaviour
{
    public static SceneGame sceneGame;
    public string player_name;
    public float poin;

    Poin poinObj;
    public TextMeshProUGUI player_name_text;

    // Start is called before the first frame update
    public void Awake()
    {
        player_name_text.text = SceneMenu.sceneMenu.player_name;
        player_name = SceneMenu.sceneMenu.player_name;

        poinObj = GameObject.Find("Poin").GetComponent<Poin>();

        if (sceneGame == null)
        {
            sceneGame = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneMenu.sceneMenu.Destroy();
    }

    void Update()
    {
        poin = poinObj.poin;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
