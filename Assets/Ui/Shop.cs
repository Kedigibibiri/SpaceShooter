using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public void ShootSpeed()
    {
        int balance = PlayerPrefs.GetInt("money") - PlayerPrefs.GetInt("price0");
        if (PlayerPrefs.GetInt("price0") > PlayerPrefs.GetInt("money")) Debug.Log("no money");

        if (balance >= PlayerPrefs.GetInt("price0"))
        {
            PlayerPrefs.SetInt("money", balance);
            PlayerPrefs.SetInt("price0", PlayerPrefs.GetInt("price0") + (PlayerPrefs.GetInt("price0") / 2));
            PlayerPrefs.SetFloat("shootspeed", PlayerPrefs.GetFloat("shootspeed") - .0125f);
        }
    }

    public void FirePower()
    {
        int balance = PlayerPrefs.GetInt("money") - PlayerPrefs.GetInt("price0");
        if (PlayerPrefs.GetInt("price1") > PlayerPrefs.GetInt("money")) Debug.Log("no money");

        if (balance >= PlayerPrefs.GetInt("price1"))
        {
            PlayerPrefs.SetInt("money", balance);
            PlayerPrefs.SetInt("price1", PlayerPrefs.GetInt("price1") + (PlayerPrefs.GetInt("price1") / 2));
            PlayerPrefs.SetFloat("bulletdamage", PlayerPrefs.GetFloat("bulletdamage") + .5f);
        }
    }

    public void RotationSpeed()
    {
        int balance = PlayerPrefs.GetInt("money") - PlayerPrefs.GetInt("price1");
        if (PlayerPrefs.GetInt("price2") > PlayerPrefs.GetInt("money")) Debug.Log("no money");

        if (balance >= PlayerPrefs.GetInt("price2"))
        {
            PlayerPrefs.SetInt("money", balance);
            PlayerPrefs.SetInt("price2", PlayerPrefs.GetInt("price2") + (PlayerPrefs.GetInt("price2") / 2));
            PlayerPrefs.SetFloat("rotationspeed", PlayerPrefs.GetFloat("rotationspeed") + .25f);
        }
    }

    public void Health()
    {
        int balance = PlayerPrefs.GetInt("money") - PlayerPrefs.GetInt("price2");
        if (PlayerPrefs.GetInt("price3") > PlayerPrefs.GetInt("money")) Debug.Log("para az");

        if (balance >= PlayerPrefs.GetInt("price3"))
        {
            PlayerPrefs.SetInt("money", balance);
            PlayerPrefs.SetInt("price3", PlayerPrefs.GetInt("price3") + (PlayerPrefs.GetInt("price3") / 2));
            PlayerPrefs.SetInt("maxhealth", PlayerPrefs.GetInt("maxhealth") + 1);
        }
    }
}
