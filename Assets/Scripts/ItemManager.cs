using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Text descriptionText; // ������ ���� �ؽ�Ʈ

    public int bulletIncreaseAmount = 1;
    public float timeIncreaseAmount = 10f;
    public int hpIncreaseAmount = 10;

    bool isTimeItem = false;
    bool isBulletItem = false;
    bool isHpItem = false;

    public TimeUI time;
    public PlayerController hp;
    public PlayerShoot bullet;

    public PlayerEventModule itemCount;

    private AudioSource audioSource;
    public AudioClip explainSound;
    public AudioClip useSound;

    private void Start()
    {
        HideDescription();
        audioSource = GetComponent<AudioSource>();
    }

    public void ShowDescription(string description)
    {
        audioSource.PlayOneShot(explainSound);
        descriptionText.text = description;
    }

    public void HideDescription()
    {
        descriptionText.text = string.Empty;
    }

    public void TimeDescription()
    {
        isTimeItem = true;
        isBulletItem = false;
        isHpItem = false;
        ShowDescription("�ð��� 10�� �����ϴ� �������Դϴ�.");
    }

    public void HpDescription()
    {
        isTimeItem = false;
        isBulletItem = false;
        isHpItem = true;
        ShowDescription("ü���� 10 ȸ���Ǵ� �������Դϴ�.");
    }

    public void BulletDescription()
    {
        isTimeItem = false;
        isBulletItem = true;
        isHpItem = false;
        ShowDescription("�Ѿ��� 1�� �����Ǵ� �������Դϴ�.");
    }

    public void Use()
    {
        audioSource.PlayOneShot(useSound);

        if (isTimeItem && itemCount.item_t > 0)
        {
            itemCount.item_t -= 1;
            time.IncreaseTime(timeIncreaseAmount);
        }

        if (isBulletItem && itemCount.item_b > 0)
        {
            if (bullet.currentBullets + bulletIncreaseAmount <= bullet.maxBullets)
            {
                itemCount.item_b -= 1;
                bullet.currentBullets += bulletIncreaseAmount;
            }
        }

        if (isHpItem && itemCount.item_h > 0)
        {
            if (hp.currentHealth + hpIncreaseAmount <= hp.maxHealth)
            {
                itemCount.item_h -= 1;
                hp.currentHealth += hpIncreaseAmount;
            }
        }
    }
}
