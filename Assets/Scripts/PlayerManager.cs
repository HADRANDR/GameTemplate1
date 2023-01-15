using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour
{
    #region Variables
    public EnemyManager enemyManager;
    [SerializeField] MenuManagerInGameScene menuManager;
    public PlayerController playerController;
    private float health = 100f;
    private readonly float BulletSpeed = 400f;
    private readonly float damage = 10f;
    public float lifeanim = 3f;
    Transform Muzzle;
    public Transform Bullet, floatingText, bloodParticle;
    public Slider slider;
    bool mouseIsNotOverUI;
    public int sayac = 5;
    #endregion
    void Start()
    {
        Muzzle = transform.GetChild(0);
        slider.maxValue = health;
        slider.value = health;
    }
    void Update()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;
        if (Input.GetMouseButtonDown(0)&&mouseIsNotOverUI)
        {
            ShootBullet();
            PlayerPrefs.SetInt("ShotBullet", PlayerPrefs.GetInt("ShotBullet") + 1);
            GameObject.Find("ShotBulletText").GetComponent<Text>().text = "SHOT BULLET : " + PlayerPrefs.GetInt("ShotBullet").ToString();
        }
    }
    public void GetDamage(float damage)
    {
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();
        if ((health - damage)>=0)
        {
            health -= damage;
            slider.value = health;
        }      
        else
        {
            health = 0;
            slider.value = health;
        }
    }
    public void AmIDead()
    {
        if (health<=0)  
        {
            Instantiate(bloodParticle, transform.position, Quaternion.identity);
            menuManager.DeathPanelOn();
            Destroy(this.gameObject);           
        }
    }
    void ShootBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(Bullet, Muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(Muzzle.forward * BulletSpeed);       
    }

    #region TriggerControls
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("engel"))
        {

            if ((health - damage) >= 0)
            {
                health -= damage;
                slider.value = health;
            }
            else
            {
                health = 0;
                slider.value = health;
            }
            playerController.movespeed = 1.5f;
            AmIDead();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerController.movespeed = 3f;
    }
}
#endregion

