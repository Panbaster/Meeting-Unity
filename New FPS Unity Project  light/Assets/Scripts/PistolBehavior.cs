using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBehavior : MonoBehaviour {

    public Bullet Bullet;
    public float bulletSpeed;
    public float bulletDamage;
    public float shootDealy;

    Bullet bullet;
    float lastTimeShooted;

    private void Start()
    {
        if (gameObject.transform.parent == null)
            GetComponent<Rigidbody>().isKinematic = false;
        else
            GetComponent<Rigidbody>().isKinematic = true;
    }

    public void Shoot () {

        //checking for fire rate
        if (Time.time - lastTimeShooted >= shootDealy)
        {
            //creating preFab and sending parametrs
            bullet = Instantiate(Bullet, transform.TransformPoint(Vector3.forward * 0.25f), transform.rotation);
            bullet.speedDetailsInScript = bulletSpeed;
            bullet.damageDetailsInScript = bulletDamage;
            bullet.ownerDetailsInScript = GetComponent<ItemControler>().callerDetailsInScript;

            lastTimeShooted = Time.time;
        }
	}

    public void OnInteraction()
    {
        //asking inventory controller to add itself
        GetComponent<ItemControler>().callerDetailsInScript.GetComponent<InventoryControler>().AddItem(transform.gameObject);
    }

}
