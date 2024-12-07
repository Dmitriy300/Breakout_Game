using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;
using UnityEngine.UIElements;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame Instance { get; private set; }

    public GameObject StartScreen;
    public GameObject WinScreen;
    public GameObject EndScreen;
    public Ball Ball;
    public TextMeshProUGUI ScoreBoard;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI LivesCounter;


    private bool _isGameRunning = false;
    private bool _isGameOver = false;
    [SerializeField] private int _score = 0;
    private float _timeRunning = 0;
    private int _brickCount = 0;

    private void Awake()
    {
        Instance = this;
        _brickCount = Object.FindObjectsOfType<Brick>().Length;
        Debug.Log("Количество Brick на сцене: " + _brickCount);
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
        if (!_isGameOver)
        {

            if (!_isGameRunning && Input.GetButton("Jump"))
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

            if (_isGameRunning)
            {
                _timeRunning += Time.deltaTime;

                //Timer.text = ((int)(_timeRunning / 60)) + ":" + ((int)(_timeRunning % 60));
                UpdateTimer();
                UpdateLivesCounter(); // Обновляем счетчик жизней

                if (_score >= _brickCount)
                {
                    GameWin();
                }
            }

            
        }

       
    }

    public void BrickDestroyed()
    {
        _score++;
        ScoreBoard.text = _score.ToString();

        // Проверка, остались ли еще блоки
        if (_score >= _brickCount)
        {
            GameWin();
        }
        
    }

    public void SetBrickCount(int count) // Метод для установки количества блока
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
            LivesCounter.text = "Lives: " + Ball.CurrentLives.ToString(); // Обновляем текст жизней
        }
    }
}
