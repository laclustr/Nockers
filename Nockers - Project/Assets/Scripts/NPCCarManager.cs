using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCCarManager : MonoBehaviour
{
    private List<GameObject> npcCars = new List<GameObject>();
    public string winSceneName = "WinScreen"; // Name of the win scene

    private void Start()
    {
        NPCVehicle[] npcCarComponents = FindObjectsOfType<NPCVehicle>();
        foreach (NPCVehicle npcCarComponent in npcCarComponents)
        {
            npcCars.Add(npcCarComponent.gameObject);
        }
    }

    public void DestroyNPCVehicle(GameObject npcCar)
    {
        npcCars.Remove(npcCar);
        Destroy(npcCar);

        // Check if all NPC cars are destroyed
        if (npcCars.Count == 0)
        {
            // Display the "You Win" screen or perform any other actions
            LoadWinScene();
        }

        // Call ObjectiveTracker to track the destroyed NPC vehicle
        ObjectiveTracker objectiveTracker = FindObjectOfType<ObjectiveTracker>();
        objectiveTracker.NPCVehicleDestroyed();
    }

    void LoadWinScene()
    {
        SceneManager.LoadScene(winSceneName); // Load the "WinScreen" scene
    }
}
