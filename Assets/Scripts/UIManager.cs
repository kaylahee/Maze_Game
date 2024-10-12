using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject uiScreen;

    private AudioSource audioSource;
    public AudioClip qSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Q Ű�� ������ UI ȭ�� ���
        if (Input.GetKeyDown(KeyCode.Q))
		{
            audioSource.PlayOneShot(qSound);
            ToggleUIScreen();
		}
    }

    private void ToggleUIScreen()
	{
        //UI ȭ���� Ȱ��ȭ �Ǵ� ��Ȱ��ȭ
        uiScreen.SetActive(!uiScreen.activeSelf);
    }
}
