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
        //충돌한 오브젝트의 이름이 Monster일 경우
        if (other.CompareTag("Monster") || other.CompareTag("Obstacle"))
        {
            //충돌한 오브젝트를 파괴
            Destroy(other.gameObject);
            //자기 자신도 파괴
            Destroy(this.gameObject);
        }
    }
}
