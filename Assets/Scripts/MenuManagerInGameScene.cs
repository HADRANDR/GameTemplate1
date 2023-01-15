using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TigerForge;

public class MenuManagerInGameScene : MonoBehaviour
{
    #region Variables
    public GameObject InGameScreen, PauseScreen;
    [SerializeField] GameObject deathPanel;
    [SerializeField] GameObject winPanel;

    #endregion

    #region Buttons
    public void PauseButton()
    {
        Time.timeScale = 0;
        InGameScreen.SetActive(false);
        PauseScreen.SetActive(true);
    }
    public void PlayButton()
    {
        PauseScreen.SetActive(false);
        InGameScreen.SetActive(true);
        Time.timeScale = 1;
    }
    public void RePlayButton()
    {
        PlayerPrefs.SetInt("totalShotBullet", PlayerPrefs.GetInt("totalShotBullet") + PlayerPrefs.GetInt("ShotBullet"));
        PlayerPrefs.SetInt("totalKilledEnemy", PlayerPrefs.GetInt("totalKilledEnemy") + PlayerPrefs.GetInt("KilledEnemy"));
        PlayerPrefs.SetInt("KilledEnemy", 0);
        PlayerPrefs.SetInt("ShotBullet", 0);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void HomeButton()
    {
        PlayerPrefs.SetInt("totalShotBullet", PlayerPrefs.GetInt("totalShotBullet") + PlayerPrefs.GetInt("ShotBullet"));
        PlayerPrefs.SetInt("totalKilledEnemy", PlayerPrefs.GetInt("totalKilledEnemy") + PlayerPrefs.GetInt("KilledEnemy"));
        PlayerPrefs.SetInt("KilledEnemy", 0);
        PlayerPrefs.SetInt("ShotBullet", 0);
        SceneManager.LoadScene(0);
    }
    #endregion

    #region PanelControl
    public void DeathPanelOn()
    {
        deathPanel.SetActive(true);
    }
    public void WinPanelOn()
    {
        winPanel.SetActive(true);
    }
    #endregion

}