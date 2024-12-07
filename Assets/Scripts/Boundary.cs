using UnityEngine;

public class Boundary : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // Сравниваем с тегом мяча
        {
            Ball ball = other.GetComponent<Ball>();

            if (ball != null)
            {
                ball.LoseLife(); // Вызываем метод потери жизни
            }
        }
    }
}
