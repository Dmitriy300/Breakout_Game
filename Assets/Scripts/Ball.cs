using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _maxLives = 3; 
    [SerializeField] private Transform paddle;
    [SerializeField] private float _respawnHeight = 1.0f;
    [SerializeField] private AudioClip _hitSoundBall;
    [SerializeField] private AudioClip _hitSoundBlock;

    private AudioSource _audioSource;
    private int _currentLives;
    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentLives = _maxLives;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            _audioSource.PlayOneShot(_hitSoundBall);
        }
        else if (collision.gameObject.CompareTag("Block"))
        {
            _audioSource.PlayOneShot(_hitSoundBlock);
        }
    }

    public void Accelerate()
    {
        float move_x = Random.Range(0, 2) == 0 ? -1 : 1;
        float move_y = Random.Range(0, 2) == 0 ? -1 : 1;

        GetComponent<Rigidbody>().linearVelocity = new Vector3(_speed * move_x, _speed * move_y, 0.0f);
                
    }

    private void OnBecameInvisible() // Обрабатываем, когда мяч уходит с экрана
    {
        LoseLife();
    }

    public void LoseLife()
    {
        _currentLives--;
        if (_currentLives <= 0)
        {
            Die(); 
        }
        else
        {
            Respawn(); 
        }
    }

   
    public void Respawn()
    {
        transform.position = paddle.position + new Vector3(0, _respawnHeight, 0); 
        _rigidbody.linearVelocity = Vector3.zero; 
        Accelerate();
        ManagerGame.Instance.UpdateLivesCounter();
    }

   
    private void Die()
    {
        Debug.Log("Game Over! Ball has lost all lives!");
        ManagerGame.Instance.GameOver();
        Destroy(gameObject); 
    }

    public int CurrentLives
    {
        get { return _currentLives; }
    }

}

