using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    float pullSpeed;
    [SerializeField]
    GameObject arrowPrefab;
    [SerializeField]
    GameObject arrow;
    [SerializeField]
    GameObject bow;

    [SerializeField]
    int numberOfArrows = 10;

    bool arrowSlotted = false;

    float pullAmount = 0;

    [SerializeField]
    private AudioClip bowRelease;

    private AudioSource audioSource;





    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        SpawnArrow();
    }

    // Update is called once per frame
    void Update()
    {
        ShootLogic();
    }

    void SpawnArrow()
    {
        if(numberOfArrows > 0)
        {
            arrowSlotted = true;
            arrow = Instantiate(arrowPrefab, transform.transform.position, transform.rotation) as GameObject;
            arrow.transform.parent = transform;
        }
    }


    void ShootLogic()
    {
        if (numberOfArrows > 0)
        {
            if(pullAmount > 100)
                pullAmount = 100;

            SkinnedMeshRenderer _bowSkin = bow.transform.GetComponent<SkinnedMeshRenderer>();
            SkinnedMeshRenderer _arrowSkin = arrow.transform.GetComponent<SkinnedMeshRenderer>();
            Rigidbody _arrowRigidB = arrow.transform.GetComponent<Rigidbody>();
            ProjectileForce _arrowProjectile = arrow.transform.GetComponent<ProjectileForce>();
            

            if (Input.GetMouseButton(0) && UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject == null)
            {
                pullAmount += Time.deltaTime * pullSpeed;
            }
            if(Input.GetMouseButtonUp(0) && UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject == null)
            {
                
                arrowSlotted = false;
                _arrowRigidB.isKinematic = false;
                arrow.transform.parent = null;             
                _arrowProjectile.shootForce = _arrowProjectile.shootForce * ((pullAmount / 100) + .05f);
                numberOfArrows -= 1;
                audioSource.PlayOneShot(bowRelease);

                pullAmount = 0;

                _arrowProjectile.enabled = true;

            }

            _bowSkin.SetBlendShapeWeight(0, pullAmount);
            _arrowSkin.SetBlendShapeWeight(0, pullAmount);

            if(Input.GetMouseButtonDown(0) && arrowSlotted == false && UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject == null)
            {
                SpawnArrow(); 
            }
        }
    }
}
