using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalCameraHandler : MonoBehaviour
{
    public Transform cameraAnchorPoint;

    public float cameraRotationX = 0;
    public float cameraRotationY = 0;

    Vector2 viewInput;


    SeekerCharacterController seekerCharacterController;
    Camera localCamera;


    private void Awake()
    {
        localCamera = GetComponent<Camera>();
        seekerCharacterController = GetComponentInParent<SeekerCharacterController>();
    }


    // Start is called before the first frame update
    void Start()
    {
        if (localCamera.enabled)
            localCamera.transform.parent = null;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (cameraAnchorPoint == null)
            return;

        if (!localCamera.enabled) return;

        localCamera.transform.position = cameraAnchorPoint.position;

        cameraRotationX += viewInput.y * Time.deltaTime * seekerCharacterController.viewUpDownRotationSpeed;
        cameraRotationX = Mathf.Clamp(cameraRotationX, -90, 90);

        cameraRotationY += viewInput.x * Time.deltaTime * seekerCharacterController.rotationSpeed;

        localCamera.transform.rotation = Quaternion.Euler(cameraRotationX, cameraRotationY, 0);
    }

    public void SetViewInputVector (Vector2 viewInput)
    {
        this.viewInput = viewInput;
    }
}
