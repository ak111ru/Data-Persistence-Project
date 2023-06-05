using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField textPlayer;
    [SerializeField] private TextMeshProUGUI bestText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.LoadBest();
        if (GameManager.instance.bestScore > 0)
        {
            bestText.text="Best: " + GameManager.instance.bestPlayer + ": " + GameManager.instance.bestScore;
            textPlayer.text = GameManager.instance.bestPlayer;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        //Debug.Log("'"+textPlayer.text+"'");
        if (textPlayer.text.Length>1)
        {
            GameManager.instance.currentPlayer = textPlayer.text;
            SceneManager.LoadScene(1);
        }        
    }

    public void Exit()
    {        
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
