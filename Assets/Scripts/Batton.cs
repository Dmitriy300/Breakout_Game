using UnityEngine;

public class Batton : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null) 
        {
            ManagerGame.Instance.GameOver();
            
        }
        
    }
}
