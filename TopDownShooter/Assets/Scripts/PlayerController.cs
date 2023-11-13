using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject pistol;
    public GameObject machinegun;
    public Transform PlayerPos;
    public static int equippedGun = 0; //verifica qual arma esta selecionada
    Vector2 moveInput;
    public static float moveSpeed = 5; //velocidade do player
    Animator anim;
    public static float playerlives= 5;
    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMove(); //função para movimentar o personagem
        gunSelected(); //verifica qual arma esta selecionada e a equipa
    }
    void playerMove() //comando de movimentação de personagem
    {
        moveInput.x = Input.GetAxis("Horizontal");  
        moveInput.y = Input.GetAxis("Vertical");
        transform.Translate(moveInput * Time.deltaTime * moveSpeed);

        anim.SetBool("Move",(Mathf.Abs(moveInput.x) >0 || Mathf.Abs(moveInput.y) > 0)); //ativa animção de andar
    }
    void gunSelected()
    {
        if (equippedGun == 1) //caso a arma equipada seja a º1
        {
            Instantiate(pistol,PlayerPos); //spawna uma pistola como filho do game object player
            equippedGun = 0; // faz a variavel virar 0 para não spawnar pistolas infinitas
        }
        else if (equippedGun == 2) //caso a arma equipada seja a º2
        {
            Instantiate(machinegun,PlayerPos); //spawna uma metralhadora como filho do game object player
            equippedGun = 0;// faz a variavel virar 0 para não spawnar pistolas infinitas
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")) //verifica se colidiu com um inimigo
        {
            playerlives--; //reduz 1 de vida
        }
        if (playerlives <= 0) //se a qtd de vidas for menor ou = a 0 
        {
            Destroy(gameObject); //destroy o player
        }
    }
}
