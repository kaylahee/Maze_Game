using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEventModule : MonoBehaviour
{
    public Text Item_Bullet;
    public Text Item_Time;
    public Text Item_HP;

    public int item_b = 0;
    public int item_t = 0;
    public int item_h = 0;

    public GameObject fireworksPrefab;
    public float delayInSeconds = 2f;
    public GameObject ExitPanel;

    public AudioClip b_ItemPickup;
    public AudioClip t_ItemPickup;
    public AudioClip h_ItemPickup;

    public AudioClip success;
    public AudioSource backGroundMusic;
    public AudioSource walkingMusic;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        UpdateItemAcountText();

        if (ExitPanel.activeSelf)
        {
            backGroundMusic.Stop();
            walkingMusic.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item_Bullet"))
        {
            item_b++;
            audioSource.PlayOneShot(b_ItemPickup);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Item_Time"))
        {
            item_t++;
            audioSource.PlayOneShot(t_ItemPickup);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Item_HP"))
        {
            item_h++;
            audioSource.PlayOneShot(h_ItemPickup);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("ArrivePoint"))
        {
            audioSource.PlayOneShot(success);

            // 气磷 积己
            fireworksPrefab.SetActive(true);

            StartCoroutine(ShowPanelWithDelay());

            Destroy(other.gameObject);
        }
    }

    private void UpdateItemAcountText()
    {
        Item_Bullet.text = item_b.ToString();
        Item_Time.text = item_t.ToString();
        Item_HP.text = item_h.ToString();
    }

    IEnumerator ShowPanelWithDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);

        // 菩澄 积己 棺 劝己拳
        ExitPanel.SetActive(true);
    }
}
