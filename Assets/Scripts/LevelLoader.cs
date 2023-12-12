using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private TMP_Text _leveText;

    private void Start()
    {
       

        _leveText.text = "Уровень " + (Progress.Instance.Level + 1).ToString();
    }
    public void StartLevel()
    {
        int level = Progress.Instance.Level;
        SceneManager.LoadScene(level + 1); 
    }
}
