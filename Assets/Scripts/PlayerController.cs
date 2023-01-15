using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region Variables
    Rigidbody2D PlayerRB;
    Animator PlayerAnimator;
    public float movespeed = 3f;
    private readonly int JumpPower = 300;
    public bool FaceControl = true;
    bool JumpControl;
    float AnimatorControl = 0f;
    float JumpAnimatorControl = 0f;
    #endregion

    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
    }
    void FlipFace() //Oyuncunun yüzünü çeviren algoritma
    {
        FaceControl = !FaceControl;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }
    void OnCollisionEnter2D(Collision2D collisioninfo)
    {
        JumpControl = true; //Zıplama gerçekleşmesi için bool değer "true" olur.
        JumpAnimatorControl = 0f; // Havadan tekrar zemine temasta Zıplama animasyonunu kapatmak için sıfırlanır.
        PlayerAnimator.SetFloat("PlayerJump", Mathf.Abs(JumpAnimatorControl));
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        movespeed = 3f;
    }
    void PlayerControl() //Oyuncunun hareket mekanik algoritması
    {
        if (Input.GetKey(KeyCode.D)) //SOL YÖN
        {
            transform.Translate(movespeed * Time.deltaTime, 0, 0);
            AnimatorControl = 1f; //Run Animasyonunun devreye girmesini sağlar.
            PlayerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(AnimatorControl)); //Animator kontroldeki değeri "PlayerSpeed" tag animasyonuna çeker.
            if (FaceControl == false) //Oyuncunun baktığı yönü kontrol eder. Şart sağlanıyorsa yön çevirir.
            {
                FlipFace();
            }

        }
        if (Input.GetKey(KeyCode.A)) //SAĞ YÖN
        {
            transform.Translate(-movespeed * Time.deltaTime, 0, 0);
            AnimatorControl = 1f; //Run Animasyonunun devreye girmesini sağlar.
            PlayerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(AnimatorControl)); //Animator kontroldeki değeri "PlayerSpeed" tag animasyonuna çeker.
            if (FaceControl == true) //Oyuncunun baktığı yönü kontrol eder. Şart sağlanıyorsa yön çevirir.
            {
                FlipFace();

            }
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) //Karakter hareketi sonlandığında Run Animasyonunu bitirir.
        {
            AnimatorControl = 0f;
            PlayerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(AnimatorControl));
        }
        if (Input.GetKeyDown(KeyCode.Space)) //Zıplama hareketini başlatır.
        {
            if (JumpControl == true)
            {
                JumpAnimatorControl = 1f;
                //JumpAnimatorControl = 1f; // Zıplama animasyonunu devreye sokmak için değişkene değer yükler.
                PlayerRB.AddForce(new Vector2(0, JumpPower));
                PlayerAnimator.SetFloat("PlayerJump", Mathf.Abs(JumpAnimatorControl));
                JumpControl = false;
            }
        }
    }
    void Update()
    {
        PlayerControl();
    }



}
