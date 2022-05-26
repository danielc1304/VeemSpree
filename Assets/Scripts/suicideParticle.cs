using UnityEngine;

public class suicideParticle : MonoBehaviour
{
    AudioSource source;
    [SerializeField] AudioClip particleSound;
    [SerializeField] float volume;
    void Start()
    {
        source = this.GetComponent<AudioSource>();
        source.PlayOneShot(particleSound, volume);
        Invoke("die", 4f);
    }

    private void die()
    {
        Destroy(this.gameObject);
    }
}
