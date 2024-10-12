using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public Text bullettext;

    public int maxBullets = 10;
    public int currentBullets;

    public PlayerBulletBar bulletBar;

    // Start is called before the first frame update
    void Start()
    {
        currentBullets = maxBullets;
        bulletBar = FindObjectOfType<PlayerBulletBar>();
        bulletBar.UpdateBulletBar(currentBullets, maxBullets);
    }

    // Update is called once per frame
    void Update()
    {
        bulletBar.UpdateBulletBar(currentBullets, maxBullets);

        if (Input.GetMouseButtonDown(1))
        {
            if (currentBullets > 0)
            {
                ShootBullet();
                currentBullets--;
            }
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(bulletRigidbody.transform.forward * 500f);

        // �Ѿ��� �浹 �Ǵ� ���� �ð��� ����� �Ŀ� �ı��ǵ��� ����
        Destroy(bullet, 5f);
    }
}
