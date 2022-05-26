using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shotOrigin;
    [SerializeField] Transform gunParent;
    [SerializeField] GameObject shotParticles;
    AudioSource gunAudio;
    Animator shotAnim;

    private void Start()
    {
        shotAnim = this.GetComponent<Animator>();
        gunAudio = this.GetComponent<AudioSource>();
    }

    public void shoot()
    {
        Instantiate(bullet, shotOrigin.position, shotOrigin.rotation);
        Instantiate(shotParticles, transform.position, transform.rotation);
        Debug.Log(gunParent.rotation);
        shotAnim.Play("shoot");
        gunAudio.Play();
    }
}
