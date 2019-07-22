using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //Change this value in weapon script
    public float lifeTime=90;
    //public variables for other scripts
    public GameObject ownerDetailsInScript;
    //to change this values look at weapon behavior script
    public float speedDetailsInScript;
    public float damageDetailsInScript;

    GameObject buff;

    
    void Update()
    {
        //bullet movement
        transform.position += transform.TransformVector(Vector3.forward * speedDetailsInScript * Time.deltaTime);
        //Lifetime for object
        lifeTime -= Time.deltaTime;
        if(lifeTime<=0)
            Destroy(this.gameObject);
    }


    void OnTriggerEnter(Collider collision)
    {
        Destroy(gameObject,0f);

        //Cuting self damage
        buff = collision.gameObject;
        while (true)
        {
            if (buff == ownerDetailsInScript)
                return;
            if (buff.transform.parent==null)
                break;
            buff = buff.transform.parent.gameObject;
        }

        //sending damage to healthControler through damagePoint
        if (collision.gameObject.GetComponent<DamagePoint>() != null)
            collision.gameObject.GetComponent<DamagePoint>().HealthModifier(damageDetailsInScript);

        
    }






}
