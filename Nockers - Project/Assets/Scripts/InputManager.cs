using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    private EventSystem eventSystem;

    private void Start()
    {
        eventSystem = EventSystem.current;
    }

    private void Update()
    {
        // Check if the current selected game object is null or if it's not a button
        if (eventSystem.currentSelectedGameObject == null ||
            !eventSystem.currentSelectedGameObject.GetComponent<UnityEngine.UI.Button>())
        {
            SelectDefaultButton();
        }
    }

    private void SelectDefaultButton()
    {
        // Find the first selectable button in the scene and select it
        UnityEngine.UI.Button[] buttons = FindObjectsOfType<UnityEngine.UI.Button>();
        if (buttons.Length > 0)
        {
            eventSystem.SetSelectedGameObject(buttons[0].gameObject);
        }
    }
}
