using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 200f;
    public float fireRate = 15f;
    public float impactForce = 30f;
    public int currentAmmo;
    public int maxAmmo = 50;
    public bool isReloading=false;
    public AudioSource audioSource;
    public Camera cam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    private float nextToFire = 0f;
    private UImanager uiManager;
    void Start()
    {
        currentAmmo = maxAmmo;
        uiManager=GameObject.Find("Canvas").GetComponent<UImanager>();
    }
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time >= nextToFire && currentAmmo > 0)
        {
            currentAmmo--;
            uiManager.UpdateAmmo(currentAmmo);
            if (audioSource.isPlaying == false)
            {
                audioSource.Play();
            }

            nextToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        else
        {
            audioSource.Stop();
        }

        if (Input.GetKeyDown(KeyCode.R) && isReloading==false)
        {
            isReloading=true;
            StartCoroutine(Reload());
        }


    }
    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
        //GameObject impactG=Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        // Destroy(impactG, 2f);
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.5f);
        currentAmmo = maxAmmo;
        isReloading=false;
        uiManager.UpdateAmmo(currentAmmo);
    }
}
