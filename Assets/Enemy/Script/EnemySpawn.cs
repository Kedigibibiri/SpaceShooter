using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawn : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] float spawnSpeed;
    [SerializeField] GameObject[] enemyPool;
    int randomEnemyObj;

    [Header("Level Manager")]
    public int enemyCount;
    [SerializeField] int maxEnemyCount;
    [SerializeField] GameObject upgradeScreen;
    [SerializeField] GameObject mainScreen;

    [Header("Player")]
    public Transform player;
    bool spawn = false;
    bool GameRuning;

    void Update()
    {
        StartCoroutine(SpawnAndMove());
        maxEnemyCount = PlayerPrefs.GetInt("level") * 5;
        spawnSpeed = 3f - ((float)maxEnemyCount / 70f);

        if (upgradeScreen.activeSelf || mainScreen.activeSelf) GameRuning = false;
        if (!upgradeScreen.activeSelf && !mainScreen.activeSelf) GameRuning = true;

    }

    IEnumerator SpawnAndMove()
    {
        if (!spawn && GameRuning)
        {
            if (enemyCount >= maxEnemyCount)
            {
                if (transform.childCount <= 0)
                {
                    upgradeScreen.SetActive(true);
                    PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
                    GameRuning = false;
                    enemyCount = 0;
                }
                yield break;
            }
            if (!GameRuning) yield break;

            if (PlayerPrefs.GetInt("level") <= 5) randomEnemyObj = Random.Range(0, 4);
            if (PlayerPrefs.GetInt("level") <= 9 && PlayerPrefs.GetInt("level") > 5) randomEnemyObj = Random.Range(0, 7);
            if (PlayerPrefs.GetInt("level") >= 10) randomEnemyObj = Random.Range(0, enemyPool.Length);

            spawn = true;
            float randomx = Random.Range(-4.5f, 4.5f);
            Vector3 randompos = new(randomx, transform.position.y, transform.position.z);
            GameObject temp = Instantiate(enemyPool[randomEnemyObj], randompos, Quaternion.identity, gameObject.transform);
            int point = temp.GetComponent<Enemy>().enemyPoint;
            enemyCount += point;
            if (transform.childCount == 0) spawn = true;
            yield return new WaitForSeconds(spawnSpeed);
            spawn = false;
        }
    }

    void CleanChildren()
    {
        int childcount = transform.childCount - 1;
        for (int i = 0; i < childcount; i++) DestroyImmediate(transform.GetChild(i).gameObject);
    }
}
