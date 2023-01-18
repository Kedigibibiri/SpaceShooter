using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;
    EnemySpawn spawner;

    [Header("Enemy")]
    [SerializeField] float enemySpeed;
    [SerializeField] float enemyHealth;
    public int enemyPoint;

    [Header("Drops")] 
    [SerializeField] GameObject[] powerups;

    [Header("Particles")]
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject shipHit;

    void Start()
    {
        spawner = GetComponentInParent<EnemySpawn>();
        player = spawner.player;
        transform.LookAt(player);

        enemySpeed = 3 + (PlayerPrefs.GetInt("level") / 10f);
    }

    void Update() => transform.position = Vector3.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Bullet>())
        {
            enemyHealth -= other.GetComponent<Bullet>().bulletDamage;
            if (enemyHealth <= 0)
            {
                Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);

                int power = Random.Range(0, 100);
                if (power < 90)
                {
                    GameObject drop = Instantiate(powerups[0], gameObject.transform.position, Quaternion.identity, spawner.transform);
                    drop.GetComponent<PowerUp>().smalDrop = enemyPoint;
                }

                if (power > 96)
                {
                    GameObject drop = Instantiate(powerups[1], gameObject.transform.position, Quaternion.identity, spawner.transform);
                    drop.GetComponent<PowerUp>().bigDrop = enemyPoint * 3;
                }

                PlayerPrefs.SetInt("destroyed", PlayerPrefs.GetInt("destroyed") + 1);
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Control>())
        {
            Instantiate(shipHit, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
