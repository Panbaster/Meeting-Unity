using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    public float time;
    public Text text;
	
    //timer on UI couting seconds
	void Update () {
        time -= Time.deltaTime;
        text.text = Mathf.Round(time).ToString();
        if (time <= 0)
            gameObject.SetActive(false);
	}
}
