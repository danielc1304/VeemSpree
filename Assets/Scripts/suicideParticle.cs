using UnityEngine;

public class suicideParticle : MonoBehaviour
{

    [SerializeField] float lifetime = 4f;
    void Start()
    {
        Invoke("die", lifetime);
    }

    private void die()
    {
        Destroy(this.gameObject);
    }
}
