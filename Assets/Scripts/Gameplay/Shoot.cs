using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform gun;
    public GameObject bulletPF;

    float cooldown = 0f;
    Platformer plat;

    // Start is called before the first frame update
    private void Start()
    {
        plat = gameObject.GetComponent<Platformer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButton("Fire1") && cooldown < Time.time)
        {
            Fire();
            cooldown = Time.time + fireRate;
        }
    }

    void Fire()
    {
        float angle = plat.isFacingRight ? 0f : 180f;
        if (plat.isFacingRight == true)
            gun.localPosition = new Vector3(.75f, gun.localPosition.y, gun.localPosition.z);
        else if (plat.isFacingRight == false)
            gun.localPosition = new Vector3(-.75f, gun.localPosition.y, gun.localPosition.z);

        Instantiate(bulletPF, gun.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}
