using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public float movmentSpeed = 1;
    public float sensitivity = 1;
    public float gravityAcceleration;
    public float jumpHeigh;
    public Camera playerView;

    //public Text debugText;
    //public Slider debugSlider;

    CharacterController movement;
    float distanceToGround;
    Vector3 Acceleration;
    Vector3 buff3d;
    RaycastHit rayHit;


    private void Start()
    {
        distanceToGround = GetComponent<Collider>().bounds.extents.y;
        movement = GetComponentInChildren<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Turning inventory slot 0 to face target in sight
        if (Physics.Raycast(playerView.transform.position, playerView.transform.TransformDirection(Vector3.forward), out rayHit))
        {
            if (GetComponent<InventoryControler>())
                GetComponent<InventoryControler>().itemSlots[0].transform.LookAt(rayHit.point);
        }
        else
        {
            if (GetComponent<InventoryControler>())
                GetComponent<InventoryControler>().itemSlots[0].transform.rotation = transform.rotation;
        }

        //using item in slot 0(shooting)
        if (Input.GetButton("Mouse0"))
            if (GetComponent<InventoryControler>())
                GetComponent<InventoryControler>().UseItem(0);

        //Interacting with object(i can)
        if (Input.GetButtonDown("Interact"))
            if (Physics.Raycast(playerView.transform.position, playerView.transform.TransformDirection(Vector3.forward), out rayHit, 4))
            {
                if (rayHit.transform.GetComponent<ItemControler>())
                    rayHit.transform.GetComponent<ItemControler>().OnInteraction(gameObject);
            }


        //player rotations with mouse
        transform.Rotate(Vector3.up, Time.deltaTime * Input.GetAxis("Mouse X") * sensitivity, Space.World);
        transform.Rotate(Vector3.left, Time.deltaTime * Input.GetAxis("Mouse Y") * sensitivity, Space.Self);

        //Movment with wasd
        buff3d = transform.TransformDirection(new Vector3(Input.GetAxis("Strafe"), 0, Input.GetAxis("Forward")));
        buff3d.y = 0;
        buff3d.Normalize();
        Acceleration = buff3d * Time.deltaTime * movmentSpeed + (Acceleration.y * Vector3.up);
        //Gravity aceeleration(downwards)
        if (!IsGrounded())
            Acceleration.y -= gravityAcceleration * Time.deltaTime;
        else
            Acceleration.y = 0;

        //Jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
            Acceleration.y = jumpHeigh;
        //Applying movement
        movement.Move(Acceleration);

    }

    //can return false when player didnt falling
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distanceToGround + 0.7f);
    }

    public void DeathSequence()
    {
        //Disabling all control
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }
        GetComponent<Movement>().enabled = false;
        if (GetComponent<DamagePoint>())
            Destroy(GetComponent<DamagePoint>());
    }

}