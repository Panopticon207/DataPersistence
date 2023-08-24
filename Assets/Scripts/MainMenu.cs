using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class MainMenu : MonoBehaviour
{

    public TMP_InputField nameInput;
    public Text bestScoreText;

    private void Start()
    {
        ShowBestScore();
    }

    public void StartGame()
    {
        JsonReadWriteSystem.Instance.SaveName(nameInput.text);
        SceneManager.LoadScene(1);
    }

    public void ShowBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            UserData data = JsonUtility.FromJson<UserData>(json);

            bestScoreText.text = data.BestScore.ToString();


        }
    }

}
