using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    float speed = 30;
    float originalSpeed;
    public float RocketBoosters = 0;
    public float steerSpeed = 100;
    private Vector3 startingPosition;
    private bool fKeyHeld = false;
    private float fKeyTimer = 0f;
    private float fKeyHoldDuration = 2f;
    private float shiftSpeedMultiplier = 1.2f; // Adjust this value to change the speed increase
    private bool shiftKeyPressed = false;
    private int npcCarCount;
    private float mKeyTimer = 0f;
    private float mKeyHoldDuration = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        originalSpeed = speed;
        Application.targetFrameRate = 300;
        NPCVehicle[] npcCars = FindObjectsOfType<NPCVehicle>();
        npcCarCount = npcCars.Length;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Input.GetAxis("Vertical"));
        transform.Translate(0, RocketBoosters * Input.GetAxis("Jump") * Time.deltaTime, speed * Input.GetAxis("Vertical") * Time.deltaTime);
        transform.Rotate(0, steerSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shiftKeyPressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shiftKeyPressed = false;
            speed = originalSpeed;
        }

        if (shiftKeyPressed && Input.GetAxis("Vertical") > 0)
        {
            speed = originalSpeed * shiftSpeedMultiplier;
        }

        if (transform.position.y < -10)
        {
            RespawnCar();
        }

        if (Input.GetKey(KeyCode.F))
        {
            fKeyTimer += Time.deltaTime;

            if (!fKeyHeld && fKeyTimer >= fKeyHoldDuration)
            {
                fKeyHeld = true;
                RespawnCar();
            }
        }
        else
        {
            fKeyHeld = false;
            fKeyTimer = 0f;
        }

        if (Input.GetKey(KeyCode.M))
        {
            mKeyTimer += Time.deltaTime;

            if (mKeyTimer >= mKeyHoldDuration)
            {
                LoadTitleScene();
            }
        }
        else
        {
            mKeyTimer = 0f;
        }
    }

    void RespawnCar()
    {
        transform.position = startingPosition;
        transform.rotation = Quaternion.identity;
    }

    void LoadTitleScene()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
