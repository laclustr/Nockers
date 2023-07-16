using UnityEngine;
using UnityEngine.UI;

public class ObjectiveTracker : MonoBehaviour
{
    public Text objectiveText;
    private int totalNPCVehicles;
    private int destroyedNPCVehicles;

    void Start()
    {
        GameObject[] npcVehicles = GameObject.FindGameObjectsWithTag("NPCVehicle");
        totalNPCVehicles = npcVehicles.Length;
        UpdateObjectiveText();
    }

    public void NPCVehicleDestroyed()
    {
        destroyedNPCVehicles++;
        UpdateObjectiveText();
    }

    void UpdateObjectiveText()
    {
        objectiveText.text = destroyedNPCVehicles.ToString() + "/" + totalNPCVehicles.ToString();
    }
}