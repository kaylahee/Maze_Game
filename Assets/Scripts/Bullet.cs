using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        //�浹�� ������Ʈ�� �̸��� Monster�� ���
        if (other.CompareTag("Monster") || other.CompareTag("Obstacle"))
        {
            //�浹�� ������Ʈ�� �ı�
            Destroy(other.gameObject);
            //�ڱ� �ڽŵ� �ı�
            Destroy(this.gameObject);
        }
    }
}
