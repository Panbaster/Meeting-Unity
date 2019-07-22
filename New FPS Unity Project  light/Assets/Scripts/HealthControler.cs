using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControler : MonoBehaviour{

    public float health=1;
    public float maxHealth=1;
    public UnityEngine.Events.UnityEvent deathSequence;
    public float destructionDelay=7;

    //Health management
    public bool HealthModifier(float modifier)
    {
        health += modifier;
        if (health > maxHealth)
            health = maxHealth;
        //death sequence
        if (health <= 0)
        {
            //sending info to death controler(eavent manager for deaths)
            if (GameObject.FindGameObjectWithTag("Eavent"))
                if (GameObject.FindGameObjectWithTag("Eavent").GetComponent<DeathControler>())
                    GameObject.FindGameObjectWithTag("Eavent").GetComponent<DeathControler>().DeathEavent(gameObject.tag);

            if (deathSequence != null)
                deathSequence.Invoke();
            Invoke("DestroyDelay", destructionDelay);
            return true;
        }
        return false;
    }

    void DestroyDelay()
    {
        Destroy(gameObject);
    }
}
