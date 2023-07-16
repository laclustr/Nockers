using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTank : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset = new Vector3(0, 1, -17);

    private Quaternion initialRotation;
    private Vector3 initialPosition;
    private float initialSteerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.rotation;
        initialPosition = plane.transform.position;
        initialSteerSpeed = plane.GetComponent<Controller>().steerSpeed;
    }

    // LateUpdate is called once per frame after all Update calls
    void LateUpdate()
    {
        try
        {
            Quaternion currentRotation = Quaternion.Euler(initialRotation.eulerAngles.x, plane.transform.eulerAngles.y, initialRotation.eulerAngles.z);
            Vector3 newPosition = plane.transform.position + (currentRotation * offset);

            transform.position = newPosition;
            transform.rotation = currentRotation;

            // Sync rotation speed with car's steerSpeed
            float rotationAmount = Input.GetAxis("Horizontal") * plane.GetComponent<Controller>().steerSpeed * Time.deltaTime;
            plane.transform.Rotate(Vector3.up, rotationAmount);
        }
        catch (System.NullReferenceException)
        {
            // Handle the exception or ignore it
            // You can leave this catch block empty if you want to ignore the error
        }
    }
}
