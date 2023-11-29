using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerControllerManager : MonoBehaviour
{
    public GameObject pistol;
    public static int pistolbought = 0;
    public GameObject zero;
    public GameObject coin2;
    public GameObject machinegun;
    public static int machinegunbought = 0;
     public GameObject ten;
    public GameObject coin;
    public GameObject shotgun;
    public static int shotgunbought = 0;
     public GameObject twenty;
    public GameObject coin1;
    public static float moveSpeed = 5; //velocidade do player
    public static bool  gunIsEquipped = false;
    Animator anim;
    Vector2 moveInput;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame

     void Update()
    {
        playerMove(); //função para movimentar o personagem
        gunState();

    }

    void playerMove() //comando de movimentação de personagem
    {
        moveInput.x = Input.GetAxis("Horizontal");  
        moveInput.y = Input.GetAxis("Vertical");
        transform.Translate(moveInput * Time.deltaTime * moveSpeed);
        anim.SetBool("Move",(Mathf.Abs(moveInput.x) >0 || Mathf.Abs(moveInput.y) > 0)); //ativa animção de andar
    }

   private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("gunshop")) //verifica se colidiu com a porta da loja de arma
        {
            SceneManager.LoadScene("GunShop"); //leva para a loja de armas
    
        }

        if(collision.gameObject.CompareTag("portal")) //verifica se colidiu com o portal
        {
            if (gunIsEquipped == true){
                SceneManager.LoadScene("TopDownShooter"); //leva para o top]downshooter
                gunState();
            }
            
        }

         if(collision.gameObject.CompareTag("manager")) //verifica se colidiu com o portal
        {
            SceneManager.LoadScene("Manager"); //leva para o topdownshooter
        }
         if(IntToText.currency >= 0){
            if(collision.gameObject.CompareTag("pistol")) //verifica se colidiu com o portal
            {
                Destroy(pistol.GetComponent<BoxCollider2D>());
                Destroy(pistol);
                Destroy(zero);
                Destroy(coin2);
                IntToText.GunState = 1;
                PlayerControllerTopDownShooter.equippedGun = 1;
                gunIsEquipped = true;
            }
        }
        
        if(IntToText.currency >= 10){
            if(collision.gameObject.CompareTag("mg")) //verifica se colidiu com o portal
            {
                Destroy(machinegun.GetComponent<BoxCollider2D>());
                Destroy(machinegun);
                Destroy(ten);
                Destroy(coin);
                IntToText.GunState = 2;
                PlayerControllerTopDownShooter.equippedGun = 2;
                gunIsEquipped = true;
            }
        }

        if(IntToText.currency >= 20){
            if(collision.gameObject.CompareTag("shotgun")) //verifica se colidiu com o portal
            {
                Destroy(shotgun.GetComponent<BoxCollider2D>());
                Destroy(shotgun);
                Destroy(twenty);
                Destroy(coin1);
                IntToText.GunState = 3;
                PlayerControllerTopDownShooter.equippedGun = 3;
                gunIsEquipped = true;
            }
        }
     }
private void gunState(){    
if(IntToText.GunState > 3){
IntToText.GunState = 0;
}
        
    }
  }
 
