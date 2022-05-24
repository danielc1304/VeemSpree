using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shotOrigin;
    [SerializeField] Transform gunParent;

    public void shoot()
    {
        Instantiate(bullet, shotOrigin.position, shotOrigin.rotation);
        Debug.Log(gunParent.rotation);
    }
}
