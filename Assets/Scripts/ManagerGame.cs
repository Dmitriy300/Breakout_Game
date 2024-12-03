using TMPro;
using UnityEngine;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame Instance { get; private set; }

    public GameObject StartScreen;
    public GameObject WinScreen;
    public GameObject EndScreen;
    public Ball Ball;
    public TextMeshProUGUI ScoreBoard;
    public TextMeshProUGUI Timer;

    private bool _isGameRunning = false;
    private bool _isGameOver = false;
    [SerializeField] private int _score = 0;
    private float _timeRunning = 0;
    private int _brickCount = 0;

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

    private void Awake()
    {
        Instance = this;
        _brickCount = Object.FindObjectsOfType<Brick>().Length;
        Debug.Log("Количество Brick на сцене: " + _brickCount);
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

                Timer.text = ((int)(_timeRunning / 60)) + ":" + ((int)(_timeRunning % 60));

            }

            if (_score >= _brickCount)
            {
                GameWin();
            }
        }

       
    }

    public void BrickDestroyed()
    {
        _score++;
        ScoreBoard.text = _score.ToString();
    }
}
