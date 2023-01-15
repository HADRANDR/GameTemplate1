using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManagerMenuScene : MonoBehaviour
{
    #region Variables
    [SerializeField] DataManager dataManager;
    public GameObject dataBoard;
    public TextMeshProUGUI TotalShot, TotalKill;
    #endregion


    #region Buttons
    public void PlayButton()
    {
       
        PlayerPrefs.SetInt("ShotBullet", 0);
        PlayerPrefs.SetInt("KilledEnemy", 0);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void DataBoardButton()
    {
        dataBoard.SetActive(true);
        Debug.Log(PlayerPrefs.GetInt("KilledEnemy"));
        TotalShot.text = "TOTAL SHOT BULLET = " + PlayerPrefs.GetInt("totalShotBullet").ToString();
        TotalKill.text = "TOTAL ENEMY KILLED = " + PlayerPrefs.GetInt("totalKilledEnemy").ToString();
    }
    public void XButton()
    {
        dataBoard.SetActive(false);
    }
    public void QuitButton()
    {
        PlayerPrefs.SetInt("totalShotBullet", PlayerPrefs.GetInt("totalShotBullet") + PlayerPrefs.GetInt("ShotBullet"));
        PlayerPrefs.SetInt("totalKilledEnemy", PlayerPrefs.GetInt("totalKilledEnemy") + PlayerPrefs.GetInt("KilledEnemy"));
        Application.Quit();
    }
    #endregion
}
