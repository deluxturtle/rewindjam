using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// https://www.youtube.com/watch?v=bVo0YLLO43s
/// </summary>
public class OrbitCamera : MonoBehaviour
{

    public float mouseSensitivity = 4f;
    public float scrollSensitivity = 2f;
    public float orbitDampening = 10f;
    public float scrollDampening = 6f;
    public bool cameraDisabled = false;

    Transform cameraTransform;
    Transform parentTransform;
    Vector3 localRotation;
    float cameraDist = 10f;

    private void Start() {
        cameraTransform = transform;
        parentTransform = transform.parent;
    }
    private void LateUpdate() {
        if(Input.GetKeyDown(KeyCode.LeftShift))
            cameraDisabled = !cameraDisabled;
        if(!cameraDisabled)
        {
            //rotation of the camera based on the mouse coordinates
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            if(mouseX != 0 || mouseY != 0)
            {
                localRotation.x += mouseX * mouseSensitivity;
                localRotation.y -= mouseY * mouseSensitivity;

                //clamp the y rotation to horizon
                localRotation.y = Mathf.Clamp(localRotation.y, 0f, 90f);
            }

            //dolly
            float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
            if(scrollWheel != 0f)
            {
                float scrollAmount = scrollWheel * scrollSensitivity;
                scrollAmount *= (cameraDist * 0.3f);
                cameraDist += scrollAmount * -1f;
                cameraDist = Mathf.Clamp(cameraDist, 1.5f, 100f);
            }
        }
        Quaternion quaternion = Quaternion.Euler(localRotation.y, localRotation.x, 0);
        parentTransform.rotation = Quaternion.Lerp(parentTransform.rotation, quaternion, Time.deltaTime * orbitDampening);
        if(cameraTransform.localPosition.z != cameraDist * -1f)
        {
            cameraTransform.localPosition = new Vector3(0,0, Mathf.Lerp(cameraTransform.localPosition.z, cameraDist * -1f, Time.deltaTime * scrollDampening));
        }
    }
}
