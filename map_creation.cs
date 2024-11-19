using UnityEngine;
using System.IO;

public class map_creation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // File path to save the data
        string filePath = Application.dataPath + "/SceneData.txt";

        // Get all objects in the scene
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        // Open a StreamWriter to write the data
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Name,Position,Dimensions");

            foreach (GameObject obj in allObjects)
            {
                // Get the object's position
                Vector3 position = obj.transform.position;

                // Get the object's dimensions
                Vector3 dimensions = Vector3.zero;
                Collider collider = obj.GetComponent<Collider>();
                if (collider != null)
                {
                    dimensions = collider.bounds.size;
                }

                // Write the data to the file
                if (dimensions != null && dimensions != Vector3.zero)
                {
                    writer.WriteLine($"{obj.name},{position},{dimensions}");
                }
            }
        }

        Debug.Log("Scene data exported to: " + filePath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
