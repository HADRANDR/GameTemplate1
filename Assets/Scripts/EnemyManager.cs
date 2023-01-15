using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class EnemyManager : MonoBehaviour
{
    #region Variables
    [SerializeField] MenuManagerInGameScene menuManager;
    public float health = 20f;
    public float damage = 10f;
    public Transform floatingText;
    public Slider slider;
    #endregion
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;

    }
    #region TriggerControl
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerManager>().GetDamage(damage);
            other.GetComponent<PlayerManager>().AmIDead();
        }
        if (other.CompareTag("bullet"))
        {
            health -= damage;
            slider.value = health;
            Destroy(other.gameObject);
        }
        if (health <= 0)
        {
            PlayerPrefs.SetInt("KilledEnemy", PlayerPrefs.GetInt("KilledEnemy") + 1);
            GameObject.Find("EnemyKilledText").GetComponent<Text>().text = "ENEMY KILLED : " + PlayerPrefs.GetInt("KilledEnemy");
            Debug.Log(PlayerPrefs.GetInt("KilledEnemy"));
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            if (PlayerPrefs.GetInt("KilledEnemy") == 5)
            {
                Time.timeScale = 0;
                menuManager.WinPanelOn();
            }
        }



    }
    #endregion


}
