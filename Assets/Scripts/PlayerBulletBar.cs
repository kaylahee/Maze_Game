using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBulletBar : MonoBehaviour
{
    public Slider bulletSlider;
    public Text bulletText;

    public void UpdateBulletBar(int currentBullet, int maxBullet)
    {
        bulletSlider.value = (float)currentBullet / maxBullet;
        bulletText.text = currentBullet.ToString() + " / " + maxBullet.ToString();
    }
}
