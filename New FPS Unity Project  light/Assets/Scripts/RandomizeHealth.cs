using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeHealth : MonoBehaviour {

    public float minVall = 3;
    public float maxVall = 5;

    HealthControler healthControler;

	// Health Randomizer
	void Start () {
        //health controler witch will bee affected
        if (healthControler == null)
            healthControler = gameObject.GetComponent<HealthControler>();

        if (gameObject.GetComponent<HealthControler>() != null)
        {
            healthControler.health = Mathf.Round((Random.value * (maxVall - minVall)) + minVall);
            healthControler.maxHealth = healthControler.health;
        }
    }
}
