using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneGameOver : MonoBehaviour
{
    public TextMeshProUGUI player_poin;
    public TMP_InputField inputField;

    // Start is called before the first frame update
    public void Awake()
    {
        player_poin.text = string.Format("{0:0}", Mathf.FloorToInt(SceneGame.sceneGame.poin));
        inputField.text = SceneGame.sceneGame.player_name;

        SceneGame.sceneGame.Destroy();
    }
}
