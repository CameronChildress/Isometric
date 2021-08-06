using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 4f;

    Vector3 forward;
    Vector3 right;

    void Start()
    {
        forward = Camera.main.transform.forward;
        //insures y will alwasy be 0
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        //tells the rotation to be 90 deg around x axis
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    void Update()
    {
        if (Input.anyKey)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        //gives us total direction that we move in
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        //creates the rotation
        transform.forward = heading;
        //creates the movement
        transform.position += rightMovement;
        transform.position += upMovement;
    }
}
