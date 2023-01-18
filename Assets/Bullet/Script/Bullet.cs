using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage;
    [SerializeField] float bulletSpeed;
    [SerializeField] GameObject hitfx;
    [SerializeField] Material bullet;
    public Transform target;

    void Start()
    {
        bulletDamage = PlayerPrefs.GetFloat("bulletdamage");
        Destroy(gameObject, 5);
        bullet.color = new Color(1, 1 - (PlayerPrefs.GetFloat("bulletdamage")/10), 0, 1);
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position, bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            Instantiate(hitfx, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
