using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        float y = 0.0f;

        transform.Translate(x, y, 0.0f);
        var ot = transform.position;
        transform.position = new Vector3(Mathf.Clamp(ot.x,_minX,_maxX), ot.y, ot.z);

    }
}
