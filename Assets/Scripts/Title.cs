using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField] GameObject origin;
    [SerializeField] Player playerScript;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            origin.SetActive(true);
            playerScript.life = 3;
            this.gameObject.SetActive(false);
        }
    }
}
