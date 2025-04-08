using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject pipePrefab;
    public float minY;
    public float maxY;
    public float x;
    public float interval;
    void Start()
    {
        InvokeRepeating("spawn", interval, interval);
    }

    private void spawn()
    {
        GameObject instance = Instantiate(pipePrefab);

        instance.transform.position = new Vector2(x, Random.Range(minY, maxY));
        instance.layer = LayerMask.NameToLayer("Pipes");
        instance.transform.SetParent(transform);
    }
}
