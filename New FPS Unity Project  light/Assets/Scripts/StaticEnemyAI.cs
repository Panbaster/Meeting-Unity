using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StaticEnemyAI : MonoBehaviour
{

    public Transform target;
    public float maxShootingDistance;

    RaycastHit rayHit;

    private void Start()
    {
        /*if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;*/
    }
    void Update()
    {
        //Rotating pieces to aim target if it in line of sight
        if (target != null)
            if (Physics.Raycast(transform.position, target.position - transform.position, out rayHit, maxShootingDistance))
                if (rayHit.transform == target)
                {
                    if (GetComponent<InventoryControler>())
                        if (GetComponent<InventoryControler>().itemSlots[0] != null)
                            GetComponent<InventoryControler>().itemSlots[0].transform.LookAt(target);
                    transform.GetChild(0).transform.LookAt(target);
                    if (GetComponent<InventoryControler>())
                        GetComponent<InventoryControler>().UseItem(0);
                }
    }

    public void DeathSequence()
    {

    }
}
