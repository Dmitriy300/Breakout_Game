using UnityEngine;

public class Boundary : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // ���������� � ����� ����
        {
            Ball ball = other.GetComponent<Ball>();

            if (ball != null)
            {
                ball.LoseLife(); // �������� ����� ������ �����
            }
        }
    }
}
