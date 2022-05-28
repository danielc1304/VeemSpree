using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shotOrigin;
    [SerializeField] Transform gunParent;
    [SerializeField] GameObject shotParticles;
    AudioSource gunAudio;
    [SerializeField] AudioClip shotAudio;
    [SerializeField] AudioClip shotEnergy;

    private void Start()
    {
        gunAudio = this.GetComponent<AudioSource>();
    }

    public void doShoot()
    {
        gunAudio.PlayOneShot(shotAudio);
        gunAudio.PlayOneShot(shotEnergy);
        Instantiate(bullet, shotOrigin.position, shotOrigin.rotation);
        Instantiate(shotParticles, transform.position + (transform.up * -.18f), transform.rotation);
        Debug.Log(gunParent.rotation);
    }
}
