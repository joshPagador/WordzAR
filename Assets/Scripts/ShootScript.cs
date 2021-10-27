using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{

    public Transform projectileLoc;
    public GameObject projectile;
    public float projectileForce;
    private Touch touch;


    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            //if no longer touching screen
            if (touch.phase == TouchPhase.Ended && UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject==null) 
            {
                //spawn ball at projectile location and add force to it
                GameObject obj = Instantiate(projectile, projectileLoc.transform.position, projectileLoc.transform.rotation);
                obj.GetComponent<Rigidbody>().AddForce(projectileLoc.transform.forward * projectileForce);
            }

        }
    }


    //public void ShootProjectile()
    //{
    //    GameObject obj = Instantiate(projectile, projectileLoc.transform.position, projectileLoc.transform.rotation);
    //    obj.GetComponent<Rigidbody>().AddForce(projectileLoc.transform.forward * projectileForce);
    //}
}
