using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RoadManager : MonoBehaviour
{

    public GameObject roadPrefab; // Reference to the road prefab

    public Transform car; // Reference to the car object


    //private List<GameObject> activeRoads = new List<GameObject>(); // List to store active road sections
    private List<GameObject> activeRoads = new List<GameObject>(); // List to store active road sections

    private float sectionLength = 202f; // Length of each road/tunnel section

    private void Start()
    {
        // Initialize by creating initial road and tunnel sections
        activeRoads.Add(roadPrefab);
    }



    private void Update()
    {
        // Check the car's position and generate/recycle road and tunnel sections accordingly
        if (car.position.x > activeRoads[activeRoads.Count - 1].transform.position.x - 10)
        {
            GenerateRoad();
        }
    }



    private void GenerateRoad()
    {
        // Instantiate a new road section at a calculated position
        GameObject newRoad = Instantiate(roadPrefab, transform.position + Vector3.right * sectionLength * activeRoads.Count + Vector3.down * 6, Quaternion.identity);
        Collider[] colliders = Physics.OverlapSphere(newRoad.transform.position, 0.5f); // Adjust the radius as needed
        foreach (Collider collider in colliders)
        {
            if (collider != newRoad.GetComponent<Collider>())
            {
                // If the new object overlaps with an existing collider, move it slightly
                newRoad.transform.position += Vector3.up * 0.1f; // Move the object up by a small amount
                break;
            }
        }

            newRoad.gameObject.tag = "EndTunnel";


        // Find the child object named "Tunnel" within the parent object
        Transform tunnel = newRoad.transform.Find("Tunnel");
        if (tunnel != null)
        { // Change the tag of the child object
            tunnel.gameObject.tag = "Tunnel"; 
        }

        activeRoads.Add(newRoad);

    }




}
