using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class GunScript : MonoBehaviour
{
    //Changeable variables in unity.
    [Header("Gun Properties")]
    public int damage = 20;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    //Other stuff
    public Camera fpsCam;
    public ParticleSystem muzzle;
    public GameObject impact;
    public AudioSource gunShot;
    public GameController control;
    //Our rate of fire, but private
    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        //If game pause or if dead or if pointer is over UI or if level complete, don't run code.
        if (PauseMenu.GameIsPaused || control.isDead || EventSystem.current.IsPointerOverGameObject() || control.levelComplete)
        {
            return;
        }
        //instead of constant clicking, hold button down and there will be delays between shots due to fire rate
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1 / fireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        //Muzzle flash on the gun.
        muzzle.Play();
        //Gun Shot sound
        gunShot.Play();
        //Bullet direction using Raycast
        RaycastHit hit;
        //if our Raycast touches something
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //check if the target has an enemy script on them. if they do, damage them.
            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            //add a small kick back on your gun.
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            //particles to make game look pretty. destroy it after 2 seconds
            GameObject impactGO = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}