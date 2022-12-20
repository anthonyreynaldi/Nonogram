using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneMenu : MonoBehaviour
{
    public static SceneMenu sceneMenu;
    public TMP_InputField inputField;

    public string player_name;

    private void Awake()
    {
        if (sceneMenu == null)
        {
            sceneMenu = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void setPlayerName()
    {
        Debug.Log("masuk");
        player_name = inputField.text;

        SceneManager.LoadSceneAsync("Game");
    }
}
