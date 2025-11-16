using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private CharacterController characterController;

    private Quaternion rotation;

    [SerializeField]
    private float moveSpeed = 1;

    [SerializeField]
    private float runSpeed = 2;

    [SerializeField]
    private float mouseSensivity = 3;

    [SerializeField]
    private Slider staminaSlider;

    void Awake()
    {
        this.characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();
        MouseMove();
        this.transform.position = new Vector3(this.transform.position.x, 5, this.transform.position.z);
    }

    void MouseMove()
    {
        this.rotation.eulerAngles = new Vector3(this.rotation.eulerAngles.x, this.rotation.eulerAngles.y, this.rotation.eulerAngles.z);
        this.rotation.eulerAngles = this.rotation.eulerAngles + Vector3.up * Input.GetAxis("Mouse X") * mouseSensivity;
        this.transform.rotation = rotation;
    }

    void Movement()
    {
        Vector3 a = Vector3.right * Input.GetAxis("Horizontal");
        Vector3 b = Vector3.forward * Input.GetAxis("Vertical");

        bool isRunning = Input.GetAxis("Running") < 0.1;
        if (isRunning)
        {
            characterController.Move((a + b).normalized * moveSpeed);
            staminaSlider.value += 1;
        }
        else
        {
            characterController.Move((a + b).normalized * runSpeed);
            staminaSlider.value -= 1;
        }
    }
}
