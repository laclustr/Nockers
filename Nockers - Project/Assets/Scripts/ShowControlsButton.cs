using UnityEngine;

public class ShowControlsButton : MonoBehaviour
{
    public GameObject controlsPanel; // Reference to the controls panel GameObject

    public void OnShowControlsButtonClicked()
    {
        // Show or hide the controls panel based on its current state
        controlsPanel.SetActive(!controlsPanel.activeSelf);
    }
}
