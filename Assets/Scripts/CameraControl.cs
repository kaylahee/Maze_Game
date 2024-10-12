using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float sensitivity = 5f; // ī�޶� ȸ�� ����
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

        // ���콺 �Է¿� ���� ȸ�� �� ���
        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -15f, 25f); // ���� ȸ�� ����

        // ī�޶� ȸ�� ����
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        playerTransform.Rotate(Vector3.up * mouseX * sensitivity);
    }
}
