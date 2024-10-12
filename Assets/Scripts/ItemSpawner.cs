using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs; // ������ ������ �迭
    public Transform[] spawnPoints; // ������ ���� ��ġ �迭

    public float spawnInterval = 5f; // ������ ���� ����

    private void Start()
    {
        // ���� �������� ������ ���� �Լ� ȣ��
        InvokeRepeating("SpawnItem", spawnInterval, spawnInterval);
    }

    private void SpawnItem()
    {
        // ������ ���� ��ġ ����
        Transform spawnPoint = GetRandomSpawnPoint();

        // �̹� �ش� ��ġ�� �������� �ִ��� Ȯ��
        bool isOccupied = spawnPoint.childCount > 0;

        if (!isOccupied)
        {
            // ������ ������ ���� ����
            GameObject itemPrefab = itemPrefabs[Random.Range(0, itemPrefabs.Length)];

            // ������ ����
            GameObject item = Instantiate(itemPrefab, spawnPoint.position, spawnPoint.rotation);

            // ������ �������� �θ�(Transform) ����
            item.transform.SetParent(spawnPoint);
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        // ������ ���� ��ġ ����
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
}
