using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;

    private AudioManager audioManager;

    void Start()
    {
        audioManager = AudioManager.instance;
    }
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
            audioManager.PlaySound("fireSound");
        }

        void Shoot ()
        {
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Gravity_One target = hit.transform.GetComponent<Gravity_One>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
        }
    }
}
