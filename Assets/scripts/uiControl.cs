using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class uiControl : MonoBehaviour
{
    public Button TryAgain;
    public Button StartGame;
    public GameObject Fail;

    void Awake()
    {
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && StartGame.gameObject.activeSelf)
        {
            Time.timeScale = 1f;
            StartGame.gameObject.SetActive(false);
        }
    }

    public void EndGame()
    {
        Fail.gameObject.SetActive(true);
        TryAgain.gameObject.SetActive(true);
    }

}