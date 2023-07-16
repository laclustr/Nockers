using UnityEngine;

public class DisableControlsImage : MonoBehaviour
{
    public GameObject controlsImage;

    public void EnableImage()
    {
        controlsImage.SetActive(false);
    }
}
