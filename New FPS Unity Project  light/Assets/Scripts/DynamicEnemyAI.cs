using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DynamicEnemyAI : MonoBehaviour {

    public Transform target;
    public float maxShootingDistance;
    public Material deadBody;

    NavMeshAgent nma;
    RaycastHit rayHit;
    

	// Use this for initialization
	void Start () {
        nma = GetComponent<NavMeshAgent>();
        /*if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {

            nma.SetDestination(target.position);

            //Use first inventory slot if something exist in it
            if (GetComponentInChildren<InventoryControler>())
                if (GetComponentInChildren<InventoryControler>().itemSlots[0] != null)
                    GetComponentInChildren<InventoryControler>().itemSlots[0].transform.rotation = transform.rotation;
            //Check if target in line of sight
            if (Physics.Raycast(transform.position, target.position - transform.position, out rayHit, maxShootingDistance))
            {


                if (rayHit.transform == target)
                {
                    transform.LookAt(target.position);
                    //turn inventory slot 0 to face target
                    if (GetComponentInChildren<InventoryControler>())
                    {
                        if (GetComponentInChildren<InventoryControler>().itemSlots[0] != null)
                            GetComponentInChildren<InventoryControler>().itemSlots[0].transform.LookAt(target);
                        GetComponentInChildren<InventoryControler>().UseItem(0);
                    }
                }
            }
        }

    }

    public void DeathSequence()
    {
        //Disabling components so object won't do anything
        GetComponent<MeshRenderer>().material = deadBody;
        GetComponent<DynamicEnemyAI>().enabled = false;
        if (GetComponent<NavMeshAgent>())
            GetComponent<NavMeshAgent>().enabled = false;
        if (GetComponent<DamagePoint>())
            Destroy(GetComponent<DamagePoint>());
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
