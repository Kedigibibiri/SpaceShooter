using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Control : MonoBehaviour
{
    [Header("Turning & Shooting")]
    [SerializeField] float rotationSpeed;
    [SerializeField] float shootSpeed;
    [SerializeField] float bulletSpeed;
    [SerializeField] float shootAngle;
    float rpmTime;
    [Space]
    [SerializeField] int health;
    [SerializeField] TMP_Text healthText;
    [SerializeField] GameObject upgrade;
    [SerializeField] EnemySpawn spawner;

    [Header("Bullet")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gunBarel;
    GameObject closestEnemy;
    [SerializeField] ParticleSystem flash;

    void Start() => PlayerPrefs.SetInt("health", PlayerPrefs.GetInt("maxhealth"));

    void Update()
    {
        Turning();
        LevelFail();
        GetPrefs();
        if (health < 0) health = 0;
    }

    void Turning()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        float closestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null)
        {
            Quaternion target = Quaternion.LookRotation(closestEnemy.transform.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, target, rotationSpeed * Time.deltaTime);


            float angle = Vector3.Angle(transform.forward, closestEnemy.transform.position - transform.position);
            if (angle < shootAngle)
            {
                rpmTime += Time.deltaTime;
                if (rpmTime > shootSpeed)
                {
                    rpmTime = 0;
                    Shooting();
                }
            }
        }
    }

    void Shooting()
    {
        flash.Play();
        GameObject temp = Instantiate(bullet, gunBarel.position, gunBarel.rotation);
        //temp.GetComponent<Rigidbody>().AddForce(gunBarel.forward * bulletSpeed * Time.deltaTime, ForceMode.Impulse);
        temp.GetComponent<Bullet>().target = closestEnemy.transform;
    }

    void GetPrefs()
    {
        rotationSpeed = PlayerPrefs.GetFloat("rotationspeed");
        shootSpeed = PlayerPrefs.GetFloat("shootspeed");
        healthText.text = PlayerPrefs.GetInt("health").ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            PlayerPrefs.SetInt("health", PlayerPrefs.GetInt("health") - 1);
            Destroy(collision.gameObject);
        }
    }

    void LevelFail()
    {
        if (PlayerPrefs.GetInt("health") == 0)
        {
            upgrade.SetActive(true);
            spawner.enemyCount = 0;
        }
    }
}
