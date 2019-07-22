using UnityEngine;
using System.Collections;

public class door : MonoBehaviour
{
    GameObject thedoor;
    bool open;

    public void OnInteraction()
    {
        if (open == false)
        {
            transform.GetComponent<Animation>().Play("open");
            open = true;
        }
        else
        {
            transform.GetComponent<Animation>().Play("close");
            open = false;
        }
    }
}