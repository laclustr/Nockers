using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCVehicle : MonoBehaviour
{
    private float speed = 1f; // Adjust the speed as needed
    private NPCCarManager carManager; // Reference to the NPCCarManager script

    private bool isFalling = false; // Flag to track if the NPC car is falling

    private void Start()
    {
        carManager = GameObject.Find("NPCCarManager").GetComponent<NPCCarManager>();
    }

    private void Update()
    {
        // Move the NPC car forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Check if the NPC car falls below the y level of -10
        if (transform.position.y < -10f && !isFalling)
        {
            isFalling = true;
            carManager.DestroyNPCVehicle(gameObject);
        }
    }
}
