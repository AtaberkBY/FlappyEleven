using UnityEngine;

public class PipeController : MonoBehaviour
{
    private float speed = 2;
    private float lifeTime = 9;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        Destroy(gameObject, lifeTime);
    }
}
