using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    #region Variables
    public float BulletDamage = 10f;
    public float LifeTime = 3f;
    public Transform floatingText;
    #endregion
    void Start()
    {
        Destroy(this.gameObject, LifeTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(("enemy")))   
        {
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("enemy"))
        {
            Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = BulletDamage.ToString();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player") && !collision.collider.CompareTag("enemy"))
        {
            Destroy(this.gameObject);
        }
        
    }
}
