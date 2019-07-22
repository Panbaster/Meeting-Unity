using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAcceleration : MonoBehaviour {

    public Movement target;

    public void AccelerationChange()
    {
        float.TryParse(GetComponentInChildren<UnityEngine.UI.InputField>().text, out target.sensitivity);
    }

}
