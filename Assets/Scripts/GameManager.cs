using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _winWindow;
    [SerializeField] private GameObject _LoseWindow;

    public void Win()
    {
        _winWindow.SetActive(true);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Progress.Instance.SetLevel(currentSceneIndex);

    }

    public void Lose()
    {
        _LoseWindow.SetActive(true);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(Progress.Instance.Level + 2);
    }
}
