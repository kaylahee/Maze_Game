using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float sensitivity = 5f; // 카메라 회전 감도
    private Transform playerTransform;

    private float rotationX = 0f;

    private void Start()
    {
        playerTransform = transform.parent;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 마우스 입력에 따라 회전 값 계산
        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -15f, 25f); // 수직 회전 제한

        // 카메라 회전 적용
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        playerTransform.Rotate(Vector3.up * mouseX * sensitivity);
    }
}
