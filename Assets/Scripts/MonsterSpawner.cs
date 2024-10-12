using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public List<GameObject> monsterPrefabs; // 몬스터 프리팹 리스트
    public float spawnInterval = 5f; // 스폰 간격

    private List<Transform> occupiedPositions = new List<Transform>(); // 이미 점령된 스폰 위치 리스트

    private void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    private IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // 랜덤한 스폰 위치와 몬스터 프리팹 선택
            GameObject randomMonsterPrefab = GetRandomMonsterPrefab();

            // 선택한 위치가 이미 점령된 위치인지 확인
            if (IsPositionOccupied(transform))
            {
                continue; // 이미 점령된 위치라면 스폰을 건너뛰고 다음으로 넘어감
            }

            // 선택한 위치에서 몬스터 스폰
            GameObject spawnedMonster = Instantiate(randomMonsterPrefab, transform.position, transform.rotation);
            spawnedMonster.SetActive(true);

            // 점령된 위치로 추가
            occupiedPositions.Add(transform);

            yield return new WaitForSeconds(0.1f); // 몬스터 생성 간격 조절
        }
    }

    private GameObject GetRandomMonsterPrefab()
    {
        // 몬스터 프리팹 리스트에서 랜덤하게 선택
        int randomIndex = Random.Range(0, monsterPrefabs.Count);
        return monsterPrefabs[randomIndex];
    }

    private bool IsPositionOccupied(Transform spawnPosition)
    {
        // 이미 점령된 위치인지 확인
        return occupiedPositions.Contains(spawnPosition);
    }
}
