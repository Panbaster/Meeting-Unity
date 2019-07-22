using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Controler for itmes witch calling prechosen eavents and saving sender's info
public class ItemControler : MonoBehaviour {

	public string name;
    public UnityEvent funcOnUse;
    public UnityEvent funcOnInteraction;
    //for sending caller to OnUse function
    public GameObject callerDetailsInScript;

    public void OnUse(GameObject caller) {
        callerDetailsInScript = caller;
        funcOnUse.Invoke();
    }

    public void OnInteraction(GameObject caller)
    {
        callerDetailsInScript = caller;
        funcOnInteraction.Invoke();
    }
}
