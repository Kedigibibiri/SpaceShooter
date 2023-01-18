using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Drop { money, unknown};
    [SerializeField] Drop dropType;
    public int smalDrop = 1;
    public int bigDrop = 5;
    EnemySpawn spawner;
    Transform player;

    void Start()
    {
        spawner = GetComponentInParent<EnemySpawn>();
        player = spawner.player;
        transform.parent = null;
    }

    void Update() => transform.position = Vector3.MoveTowards(transform.position, player.position, 5f * Time.deltaTime);

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Control>())
        {
            if (dropType == Drop.money) PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + smalDrop); 
            if (dropType == Drop.unknown) PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + bigDrop);
            Destroy(gameObject);
        }
    }
}
