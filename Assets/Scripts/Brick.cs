using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    [SerializeField] int _health;
    private Renderer _renderer;
    
    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        
    }

  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Ball>(out var ball))
        {
            TakeDamage();
            
        }

    }

    public void TakeDamage()
    {
        _health--;

        // Измените цвет
        Color color = _renderer.material.color;
        color.a = Mathf.Max(0, color.a / 3.5f); // Убедитесь, что альфа не меньше 0
        _renderer.material.color = color;

        // Если здоровье меньше или равно нулю, уничтожьте кирпич
        if (_health <= 0)
        {
            Destroy(gameObject);
            ManagerGame.Instance.BrickDestroyed();
        }
    }

  
}
