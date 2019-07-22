using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControler : MonoBehaviour {

    //list of inventory slots
    public GameObject[] itemSlots;
        

    public void AddItem(GameObject item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
            //loocking for free slot or adding to last one
            if (itemSlots[i].transform.childCount == 0 || i == itemSlots.Length - 1)
            {
                //adding to item's parent inventory slot and seting rigidbody
                if (itemSlots[i].transform.childCount == 0)
                {
                    item.transform.parent = itemSlots[i].transform;
                    item.transform.localPosition = Vector3.zero;
                    item.transform.rotation = itemSlots[i].transform.rotation;
                    if (item.transform.GetComponent<Rigidbody>())
                    {
                        item.transform.GetComponent<Rigidbody>().isKinematic = true;
                        item.transform.GetComponent<Rigidbody>().useGravity = false;
                    }
                }
                else
                {
                    itemSlots[i].transform.GetChild(0).transform.position = item.transform.position+(Vector3.up)*0.5f;
                    if (itemSlots[i].transform.GetChild(0).transform.GetComponent<Rigidbody>())
                    {
                        itemSlots[i].transform.GetChild(0).transform.GetComponent<Rigidbody>().isKinematic = false;
                        itemSlots[i].transform.GetChild(0).transform.GetComponent<Rigidbody>().useGravity = true;
                    }
                    itemSlots[i].transform.GetChild(0).transform.parent = null;


                    if (item.transform.GetComponent<Rigidbody>())
                    {
                        item.transform.GetComponent<Rigidbody>().isKinematic = true;
                        item.transform.GetComponent<Rigidbody>().useGravity = false;
                    }
                    item.transform.parent = itemSlots[i].transform;
                    itemSlots[i].transform.GetChild(0).transform.localPosition = Vector3.zero;
                    itemSlots[i].transform.GetChild(0).transform.rotation = itemSlots[i].transform.rotation;
                }
                break;
            }

    }

    public bool UseItem(int slot)
    {
        //sending eavent on use to item controler
        if (itemSlots[slot].GetComponentInChildren<ItemControler>())
        {
            itemSlots[slot].GetComponentInChildren<ItemControler>().OnUse(transform.gameObject);
            return true;
        }
        return false;
    }
}
