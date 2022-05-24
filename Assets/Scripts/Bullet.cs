using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletVelocity;

    private void Start()
    {
        Invoke("deSpawn", 3f);
    }

    void Update()
    {
        transform.position += -transform.up * bulletVelocity * Time.deltaTime;
    }

    private void deSpawn()
    {
        Destroy(this.gameObject);
    }
}
