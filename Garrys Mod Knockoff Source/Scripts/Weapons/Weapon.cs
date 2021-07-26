using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Camera mainCamera;
    public int startAmmo;
    public int currentAmmo;
    public float fireDelay;
    private float nextTimeToFire;
    public float range;
    public Text ammoText;
    public bool isRealoading;
    public float realoadTime;

    public GameObject muzzleFlash;
    void Start()
    {
        currentAmmo = startAmmo;
    }

    
    void Update()
    {
        if(isRealoading == true)
            return;

        if(Input.GetKeyDown(KeyCode.R) && currentAmmo < startAmmo)
            StartCoroutine(Reaload());

        if(Input.GetMouseButton(0) && Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireDelay;
            Shoot();
        }
    }

    public void Shoot()
    {
        RaycastHit hit;
        muzzleFlash.SetActive(true);
        if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, range))
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(5);
            }
        }

        currentAmmo--;
        Invoke("DisableMuzzleFlash", 0.25f);

        ammoText.text = currentAmmo.ToString() + "/" + startAmmo.ToString();
        if(currentAmmo == 0)
            StartCoroutine(Reaload());
    }

    public void DisableMuzzleFlash()
    {
        muzzleFlash.SetActive(false);
    }

    public IEnumerator Reaload()
    {
        isRealoading = true;
        yield return new WaitForSeconds(realoadTime);
        isRealoading = false;
        currentAmmo = startAmmo;
        ammoText.text = currentAmmo.ToString() + "/" + startAmmo.ToString();
    }
}
