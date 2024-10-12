using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs; // 아이템 프리팹 배열
    public Transform[] spawnPoints; // 아이템 스폰 위치 배열

    public float spawnInterval = 5f; // 아이템 생성 간격

    private void Start()
    {
        // 일정 간격으로 아이템 생성 함수 호출
        InvokeRepeating("SpawnItem", spawnInterval, spawnInterval);
    }

    private void SpawnItem()
    {
        // 랜덤한 스폰 위치 선택
        Transform spawnPoint = GetRandomSpawnPoint();

        // 이미 해당 위치에 아이템이 있는지 확인
        bool isOccupied = spawnPoint.childCount > 0;

        if (!isOccupied)
        {
            // 랜덤한 아이템 종류 선택
            GameObject itemPrefab = itemPrefabs[Random.Range(0, itemPrefabs.Length)];

            // 아이템 생성
            GameObject item = Instantiate(itemPrefab, spawnPoint.position, spawnPoint.rotation);

            // 생성된 아이템의 부모(Transform) 설정
            item.transform.SetParent(spawnPoint);
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        // 랜덤한 스폰 위치 선택
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
}
