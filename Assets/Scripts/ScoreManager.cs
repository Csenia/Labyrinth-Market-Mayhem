using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TaskIcons _taskIconPrefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private FlyingItem flyingPrefab;
    [SerializeField] private Camera _camera;
    [SerializeField] private ItemIcons _itemIcons;
    public static ScoreManager Instance;
    private TaskIcons[] _tasks;
    [SerializeField] private GameManager _gameManager;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Level _level = FindObjectOfType<Level>();
        _tasks = new TaskIcons[_level.Tasks.Length];
        for (int i = 0; i < _level.Tasks.Length; i++)
        {
            TaskIcons neTaskIcon = Instantiate(_taskIconPrefab, _parent);
            neTaskIcon.Setup(_level.Tasks[i].ItemType, _level.Tasks[i].Number);
            _tasks[i] = neTaskIcon;
        }
    }

    public void AddScore(ItemType itemType, Vector3 position)
    {
        for (int i = 0; i < _tasks.Length; i++)
        {
            if (_tasks[i].ItemType == itemType)
            {
                if (_tasks[i].CurrentScore != 0)
                {
                    StartCoroutine(FlyAnimation(_tasks[i], position));
                }
            }
        }
    }

    private IEnumerator FlyAnimation(TaskIcons _tasks, Vector3 position)
    {
        FlyingItem newFlyingItem = Instantiate(flyingPrefab, _parent);
        Sprite sprite = _itemIcons.GetSprite(_tasks.ItemType);
        newFlyingItem.Setup(sprite);
        Vector3 a = _camera.WorldToScreenPoint(position);
        Vector3 b = _tasks.transform.position;
        for (float i = 0; i < 1f; i += Time.deltaTime)
        {
            newFlyingItem.transform.position = Vector3.Lerp(a, b, i);
            yield return null;
        }
        Destroy(newFlyingItem.gameObject);
        _tasks.AddOne();
       CheckWin();
    }
    private void CheckWin()
    {
        for (int i = 0; i < _tasks.Length; i++)
        {
            if (_tasks[i].CurrentScore != 0)
            {
                return;
            }
        }
        _gameManager.Win();
    }
}
