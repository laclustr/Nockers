using UnityEngine;

public class DontDestroyCanvas : MonoBehaviour
{
    private static bool isCanvasCreated = false;

    private void Awake()
    {
        if (!isCanvasCreated)
        {
            DontDestroyOnLoad(gameObject);
            isCanvasCreated = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}