using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletVelocity;
    [SerializeField] bool isEnemy;

    private void Start()
    {
        Invoke("deSpawn", 3f);
    }

    void Update()
    {
        if (!isEnemy)
        {
            transform.position += -transform.up * bulletVelocity * Time.deltaTime;
        }
        else
        {
            transform.position += transform.forward * bulletVelocity * Time.deltaTime;
        }
    }

    private void deSpawn()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        deSpawn();
    }
}
