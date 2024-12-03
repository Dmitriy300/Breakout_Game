using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed;
     

    public void Accelerate()
    {
        float move_x = Random.Range(0, 2) == 0 ? -1 : 1;
        float move_y = Random.Range(0, 2) == 0 ? -1 : 1;

        GetComponent<Rigidbody>().linearVelocity = new Vector3(_speed * move_x, _speed * move_y, 0.0f);

        
    }
}
