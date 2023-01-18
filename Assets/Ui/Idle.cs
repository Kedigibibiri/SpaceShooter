using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Idle : MonoBehaviour
{
    [SerializeField] TMP_Text away;

    void OnApplicationQuit()
    {
        PlayerPrefs.SetString("ClosedTime", System.DateTime.Now.ToString());
        PlayerPrefs.SetInt("firstenter", 1);
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("firstenter") == 0) away.text = "Shoot<br>Shoot<br>Loot<br>" + "<br>" + "<br>Press<br>start<br>to<br>play";
        if (PlayerPrefs.GetInt("firstenter") == 1)
        {
            string closedTimeString = PlayerPrefs.GetString("ClosedTime", "");
            System.DateTime closedTime = System.DateTime.Parse(closedTimeString);
            System.TimeSpan elapsedTime = System.DateTime.Now - closedTime;


            float idleEarn = (float)elapsedTime.TotalSeconds / 20;
            int earning = (int)idleEarn * PlayerPrefs.GetInt("level");
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + earning);

            gameObject.SetActive(true);
            away.text = "You Away<br>" + (int)elapsedTime.TotalSeconds + "<br>Seconds and You destroy<br>" + earning + "<br>astroids";
        }
    }

    public void StartGame() => gameObject.SetActive(false);
}
