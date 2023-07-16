using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public string winSceneName = "WinScreen";
    public float delayTime = 3f;

    private int npcCarCount;

    private void Start()
    {
        // Count the number of NPC cars in the scene
        NPCVehicle[] npcCars = FindObjectsOfType<NPCVehicle>();
        npcCarCount = npcCars.Length;
    }

    public void Update()
    {
        
    }

    public void NPCVehicleDestroyed()
    {
        npcCarCount--;

        // Check if all NPC cars are below the y level of -10
        if (npcCarCount <= 0)
        {
            // Display the "You Win" screen or perform any other actions
            Debug.Log("You Win!");
            Invoke("LoadWinScene", delayTime);
        }
        
    }

    void LoadWinScene()
    {
        SceneManager.LoadScene(winSceneName); // Load the "WinScreen" scene
    }
}
