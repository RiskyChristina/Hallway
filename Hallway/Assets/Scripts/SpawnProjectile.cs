using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    //public RotateToMouse rotateToMouse;
    public float fireRate;

    //public Camera fpsCam;
    public float range = 10f;

    private GameObject effectToSpawn;
    private float nextFire;
    
    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            SpawnVFX();
        }
    }

    void SpawnVFX()
    {
        GameObject vfx;
        if (firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position,
                firePoint.transform.rotation);
        }
        else
        {
            Debug.Log("No Fire Point");
        }
    }
}
