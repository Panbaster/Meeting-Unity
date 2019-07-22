using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapIcon : MonoBehaviour {

    public GameObject target;

	// Update is called once per frame
	void Update () {

        //Following target
        if (target != null)
        {
            transform.transform.position = new Vector3(target.transform.position.x, 0, target.transform.position.z);
            transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position, target.transform.TransformDirection(Vector3.forward));
        }
    }
}
