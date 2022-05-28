using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField] GameObject origin;
    [SerializeField] Player playerScript;
    private globalSense global;

    private void Start()
    {
        global = GameObject.FindGameObjectWithTag("global").GetComponent<globalSense>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            origin.SetActive(true);
            playerScript.life = 3;
            global.gameState = true;
            this.gameObject.SetActive(false);
        }
    }
}
