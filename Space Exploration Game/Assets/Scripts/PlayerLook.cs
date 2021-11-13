using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] Transform mainPlayerObject;
    [SerializeField] float sensitivity = 100f;
    [SerializeField] float lookDownClamp = -90f;
    [SerializeField] float lookUpClamp = 90f;

    float xRotation;

    void Update () {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        mainPlayerObject.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, lookDownClamp, lookUpClamp);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
