using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    public GameObject inputField;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartNew()
    {
        string n = inputField.GetComponent<TMP_InputField>().text;
        Debug.Log(n);
        PersistenceManager.Instance.sessionName = n;
        SceneManager.LoadScene(1);
        
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void ClearScore()
    {
        PersistenceManager.Instance.highScoreName = "";
        PersistenceManager.Instance.highScore = 0;
        PersistenceManager.Instance.SaveScore();
    }

}
