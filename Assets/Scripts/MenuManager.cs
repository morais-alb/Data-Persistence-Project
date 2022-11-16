using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class MenuManager : MonoBehaviour
{
    string path;

    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    [System.Serializable]
    class BestScoreData
    {
        public string userName;
        public int bestScore;
    }

    private void Awake()
    {
        path = Application.persistentDataPath + "/saveBestScore.json";
        if (File.Exists(path))
        {
            string jsoSavedScore = File.ReadAllText(path);
            BestScoreData savedScore = JsonUtility.FromJson<BestScoreData>(jsoSavedScore);

            bestScoreText.text = "Best Score : " + savedScore.userName + " : " + savedScore.bestScore;
        }
    }

    public void StartButtonPressed()
    {
        GameManager.Instance.namePlayer = nameInput.text;
        SceneManager.LoadScene(1);
    }
}
