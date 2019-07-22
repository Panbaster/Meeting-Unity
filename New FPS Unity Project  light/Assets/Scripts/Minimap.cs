using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

    public GameObject player;
    public float heigh=100;

    private void Update()
    {
        //script following target
        if (player != null)
        {
            transform.transform.position = new Vector3(player.transform.position.x, heigh, player.transform.position.z);
            transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position, player.transform.TransformDirection(Vector3.forward));
        }
    }
}
