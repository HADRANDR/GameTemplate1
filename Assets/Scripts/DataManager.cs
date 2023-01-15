using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        LoadBullet();
        LoadEnemy();
        DontDestroyOnLoad(gameObject);
        PlayerPrefs.SetInt("ShotBullet", 0);
        PlayerPrefs.SetInt("KilledEnemy", 0);
    }
    public int LoadBullet()
    {
        return PlayerPrefs.GetInt("totalShotBullet");
    }
    public int LoadEnemy()
    {
        return PlayerPrefs.GetInt("totalKilledEnemy");
    }
}
