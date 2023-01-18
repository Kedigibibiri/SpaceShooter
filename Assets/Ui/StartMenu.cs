using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartMenu : MonoBehaviour
{
    [SerializeField] TMP_Text destroyed;

    void Start()
    {
        destroyed.text = PlayerPrefs.GetInt("destroyed").ToString();
    }

    void Update()
    {
        
    }

    public void StartGame() => gameObject.SetActive(false);
}
