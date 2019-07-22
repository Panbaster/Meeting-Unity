using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnTriger : MonoBehaviour {

    public UnityEvent onTriggerExit;

    //Trigger for starting enemy spawns
    private void OnTriggerExit(Collider other)
    {
        var eaventManager = GameObject.FindGameObjectWithTag("Eavent");
        if (eaventManager != null)
        {
            eaventManager.GetComponent<DeathControler>().DeathEavent("");
        }
        Destroy(gameObject);
    }


}
