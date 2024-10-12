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
        //Q 키를 누르면 UI 화면 토글
        if (Input.GetKeyDown(KeyCode.Q))
		{
            audioSource.PlayOneShot(qSound);
            ToggleUIScreen();
		}
    }

    private void ToggleUIScreen()
	{
        //UI 화면을 활성화 또는 비활성화
        uiScreen.SetActive(!uiScreen.activeSelf);
    }
}
