using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;

    public string sessionName;
    public string highScoreName;
    public int highScore;

    private void Awake() {

        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void NameAdded(string name)
    {
        sessionName = name;
    }

    [System.Serializable]
    class SaveData
    {
        public string nameP;
        public int highScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        
        data.nameP = sessionName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScoreName = data.nameP;
            highScore = data.highScore;
        }
    }
}
