using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{

    public int enemyDamage = 10;
    public float range = 100f;
    public float fireRate = 15f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public int maxAmmo = 30;
    public int currentAmmo;
    public float reloadTime = 2f;
    private bool isReloading = false;

    private float nextTimeToFire = 0f;

    public Animator animator;

    public static int CurrentAmmo { get; internal set; }

    private UIManager _uiManager;

    void Start()
    {
        currentAmmo = maxAmmo;

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }
    void Update()
    {
            if (isReloading)
            return;

        if (!isReloading && Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
           nextTimeToFire = Time.time + 1f / fireRate;
           Shoot();
        }

      

    }

    void Shoot()
    {
        muzzleFlash.Play();

        currentAmmo--;
        _uiManager.UpdateAmmo(currentAmmo);

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyAI target = hit.transform.GetComponent<EnemyAI>();
            if (target != null)
            {
                target.TakeDamage(enemyDamage);
            }

            GameObject impactgameobject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactgameobject, 2f);
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;

        Debug.Log("Reloading");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - 0.5f);

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(0.5f);

        currentAmmo = maxAmmo;
        _uiManager.UpdateAmmo(currentAmmo);

        isReloading = false;

    }

}
