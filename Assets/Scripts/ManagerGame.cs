using TMPro;
using UnityEngine;

public class ManagerGame : MonoBehaviour
{
    

    public GameObject StartScreen;
    public GameObject WinScreen;
    public GameObject EndScreen;
    public GameObject PauseScreen;
    public Ball Ball;
    public TextMeshProUGUI ScoreBoard;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI LivesCounter;
    
    private bool _isGameRunning = false;
    private bool _isGameOver = false;
    private bool _isGamePaused = false;
    [SerializeField] private int _score = 0;
    private float _timeRunning = 0;
    private int _brickCount = 0;

    public static ManagerGame Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        _brickCount = Object.FindObjectsOfType<Brick>().Length;
        Debug.Log("���������� Brick �� �����: " + _brickCount);
    }
    private void GameWin()
    {
        _isGameRunning = false ;
        _isGameOver = true ;
        Destroy(Ball.gameObject);
        WinScreen.SetActive(true);
    }
    public void GameOver()
    {
        _isGameRunning = false;
        _isGameOver = true;
        Destroy(Ball.gameObject);
        EndScreen.SetActive(true);
    }

   
    private void Update()
    {
        if (_isGameOver) return;
        
        if (!_isGamePaused) 
        {

            if (!_isGameRunning && Input.GetButton("Jump"))
            {
                StartGame();

            }

            if (_isGameRunning)
            {
                _timeRunning += Time.deltaTime;
                             
                UpdateTimer();
                UpdateLivesCounter(); // ��������� ������� ������

                if (_score >= _brickCount)
                {
                    GameWin();
                }
            }

            
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
       
    }

    private void StartGame()
    {
        if (Ball != null)
        {
            Ball.Accelerate();
        }
        else
        {
            Debug.LogError("Ball is not assigned in the inspector.");
        }

        _isGameRunning = true;
        if (StartScreen != null)
        {
            StartScreen.SetActive(false);
        }
        else
        {
            Debug.LogError("StartScreen is not assigned in the inspector.");
        }
    }

    private void TogglePause()
    {
        _isGamePaused = !_isGamePaused; // ������������ ��������� �����
        if (_isGamePaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0; // ��������� �������
        PauseScreen.SetActive(true); // ���������� ����� �����
    }

    private void ResumeGame()
    {
        Time.timeScale = 1; // ������������� �������
        PauseScreen.SetActive(false); // �������� ����� �����
    }

    public void BrickDestroyed()
    {
        _score++;
        ScoreBoard.text = _score.ToString();

        // ��������, �������� �� ��� �����
        if (_score >= _brickCount)
        {
            GameWin();
        }
        
    }

    public void SetBrickCount(int count) // ����� ��� ��������� ���������� �����
    {
        _brickCount = count;
      
    }

    private void UpdateTimer()
    {
        int minutes = Mathf.FloorToInt(_timeRunning / 60);
        int seconds = Mathf.FloorToInt(_timeRunning % 60);
        Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void UpdateLivesCounter()
    {
        if (Ball != null)
        {
            LivesCounter.text = "Lives: " + Ball.CurrentLives.ToString(); // ��������� ����� ������
        }
    }
}
