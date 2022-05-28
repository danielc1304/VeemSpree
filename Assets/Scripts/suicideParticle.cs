using UnityEngine;

public class suicideParticle : MonoBehaviour
{
    void Start()
    {
        Invoke("die", 4f);
    }

    private void die()
    {
        Destroy(this.gameObject);
    }
}
