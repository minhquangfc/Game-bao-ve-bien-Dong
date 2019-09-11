using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour {
    public static GamePlayController instance;
    [HideInInspector]
    public int playerScore = 0;
    [SerializeField]
    private GameObject _pausePanel,_gameOverPanel;
    [SerializeField]
    private Text _scoreText, _endScoreText;
    void Awake()
    {
        _MakeInstance();
    }
    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        _scoreText.text = "" + playerScore;
    }

    void Update()
    {
        _UpdateGamePlayController();
    }

    void _UpdateGamePlayController()
    {
        _scoreText.text = "" + playerScore;
    }
    public void _PauseGameButton()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void _ResumeButton()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void _ReStartButton()
    {
        _gameOverPanel.SetActive(false);
        Application.LoadLevel("GamePlay");
    }
    public void _OptionButton()
    {
        Application.LoadLevel("MainMenu");
    }
    public void _PlaneDiedShowPanel()
    {
        _gameOverPanel.SetActive(true);
        _endScoreText.text = "" + playerScore;
        _scoreText.gameObject.SetActive(false);
        
    }
}
