using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonReadWriteSystem : MonoBehaviour
{
    public static JsonReadWriteSystem Instance;
    public string name;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start()
    {
        LoadData();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            string path = Application.persistentDataPath + "/savefile.json";
            string json = File.ReadAllText(path);
            UserData data = JsonUtility.FromJson<UserData>(json);
            Debug.Log(data.Name);
            Debug.Log(data.BestScore);

        }
    }

    public void SaveName(string name)
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string jsonx = File.ReadAllText(path);
            UserData datax = JsonUtility.FromJson<UserData>(jsonx);
            datax.Name = name;
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", JsonUtility.ToJson(datax));
        }
        else
        {
            UserData data = new UserData();
            data.Name = name;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", JsonUtility.ToJson(data));
        }


    }
    public void SaveScore(int bestScore)
    {

        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string jsonx = File.ReadAllText(path);
            UserData data = JsonUtility.FromJson<UserData>(jsonx);
            data.BestScore = bestScore;
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", JsonUtility.ToJson(data));
        }
        else
        {
            UserData data = new UserData();
            data.BestScore = bestScore;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", JsonUtility.ToJson(data));
        }


    }


    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            UserData data = JsonUtility.FromJson<UserData>(json);

            name = data.Name;
            bestScore = data.BestScore;

        }
    }




}
