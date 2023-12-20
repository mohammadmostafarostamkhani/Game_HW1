using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelTrigger : MonoBehaviour
{
    [SerializeField]
    public Light leftLight; // Reference to the left light
    [SerializeField]
    public Light rightLight; // Reference to the right light

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tunnel")) // Assuming the car has a "Car" tag
        {
            if (leftLight != null && rightLight != null)
            {
                // Turn on the spotlight when the car enters the tunnel
                leftLight.intensity = 40.0f;
                rightLight.intensity = 40.0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tunnel"))
        {
            if (leftLight != null && rightLight != null)
            {
                // Turn off the spotlight when the car exits the tunnel
                leftLight.intensity = 0.0f;
                rightLight.intensity = 0.0f;
            }
        }
    }
}
