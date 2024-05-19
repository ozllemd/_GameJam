using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Startgmae : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private Button button;


    private void Awake()
    {
        Time.timeScale = 0;

        button.onClick.AddListener(startGame);
    }

    public void startGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }
}
