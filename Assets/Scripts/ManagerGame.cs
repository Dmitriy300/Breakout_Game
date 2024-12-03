using UnityEngine;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame Instance { get; private set; }

    public GameObject StartScreen;
    public GameObject EndScreen;
    public Ball Ball;

    private bool _isGameRunning = false;
    [SerializeField] private int _score = 0;

    public void GameOver()
    {
        Destroy(Ball.gameObject);
        EndScreen.SetActive(true);
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (! _isGameRunning && Input.GetButton("Jump"))
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

        
    }

    public void BrickDestroyed()
    {
        _score++;
    }
}
