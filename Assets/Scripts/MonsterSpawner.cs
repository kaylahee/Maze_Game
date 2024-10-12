using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public List<GameObject> monsterPrefabs; // ���� ������ ����Ʈ
    public float spawnInterval = 5f; // ���� ����

    private List<Transform> occupiedPositions = new List<Transform>(); // �̹� ���ɵ� ���� ��ġ ����Ʈ

    private void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    private IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // ������ ���� ��ġ�� ���� ������ ����
            GameObject randomMonsterPrefab = GetRandomMonsterPrefab();

            // ������ ��ġ�� �̹� ���ɵ� ��ġ���� Ȯ��
            if (IsPositionOccupied(transform))
            {
                continue; // �̹� ���ɵ� ��ġ��� ������ �ǳʶٰ� �������� �Ѿ
            }

            // ������ ��ġ���� ���� ����
            GameObject spawnedMonster = Instantiate(randomMonsterPrefab, transform.position, transform.rotation);
            spawnedMonster.SetActive(true);

            // ���ɵ� ��ġ�� �߰�
            occupiedPositions.Add(transform);

            yield return new WaitForSeconds(0.1f); // ���� ���� ���� ����
        }
    }

    private GameObject GetRandomMonsterPrefab()
    {
        // ���� ������ ����Ʈ���� �����ϰ� ����
        int randomIndex = Random.Range(0, monsterPrefabs.Count);
        return monsterPrefabs[randomIndex];
    }

    private bool IsPositionOccupied(Transform spawnPosition)
    {
        // �̹� ���ɵ� ��ġ���� Ȯ��
        return occupiedPositions.Contains(spawnPosition);
    }
}
