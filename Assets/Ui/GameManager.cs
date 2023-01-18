using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text level;

    [Header("Balance")]
    [SerializeField] TMP_Text money;
    [SerializeField] TMP_Text unknown;

    [Header("Shop")]
    [SerializeField] TMP_Text[] prices;

    void Start()
    {
        FirstEnterGameUpdate();
        level.text = "Level " + PlayerPrefs.GetInt("level");
        gameObject.SetActive(false);
    }

    void Update()
    {
        money.text = PlayerPrefs.GetInt("money").ToString();

        for (int i = 0; i < prices.Length; i++)
        {
            prices[i].text = PlayerPrefs.GetInt("price" + i).ToString();
            Debug.Log("price" + i);
        }
    }

    public void StartGame()
    {
        level.text = "Level " + PlayerPrefs.GetInt("level");
        PlayerPrefs.SetInt("health", PlayerPrefs.GetInt("maxhealth"));
        gameObject.SetActive(false);
    }

    void FirstEnterGameUpdate()
    {
        if (PlayerPrefs.GetInt("level") == 0) PlayerPrefs.SetInt("level", 1);

        if (PlayerPrefs.GetFloat("shootspeed") == 0) PlayerPrefs.SetFloat("shootspeed", 1f);
        if (PlayerPrefs.GetFloat("rotationspeed") == 0) PlayerPrefs.SetFloat("rotationspeed", 3f);
        if (PlayerPrefs.GetFloat("bulletdamage") == 0) PlayerPrefs.SetFloat("bulletdamage", 2f);

        if (PlayerPrefs.GetInt("health") == 0) PlayerPrefs.SetInt("health", 5);
        if (PlayerPrefs.GetInt("maxhealth") == 0) PlayerPrefs.SetInt("maxhealth", 5);

        if (PlayerPrefs.GetInt("price0") == 0) PlayerPrefs.SetInt("price0", 10);
        if (PlayerPrefs.GetInt("price1") == 0) PlayerPrefs.SetInt("price1", 10);
        if (PlayerPrefs.GetInt("price2") == 0) PlayerPrefs.SetInt("price2", 20);
        if (PlayerPrefs.GetInt("price2") == 0) PlayerPrefs.SetInt("price2", 50);
    }
}
