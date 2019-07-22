using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePoint : MonoBehaviour {

    public HealthControler healthControler;
    public float healthModifier = 1;

    private void Start()
    {
        //aplaing healthControler if it wasnt done in inspector
        if (healthControler == null)
            healthControler = GetComponentInParent<HealthControler>();
    }

    //function called by bullet to inflict damage
    public bool HealthModifier(float modifier)
    {
        return healthControler.HealthModifier(modifier * healthModifier);
    }

}
