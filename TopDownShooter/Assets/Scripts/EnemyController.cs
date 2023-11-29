using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{ 
    public float speed;
    GameObject Player;
    Animator anim;
    bool isAlive = true;
    private int lives = 6;
    public AudioSource deathFx;
    
    


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyMove(); //função que faz o inimigo

        
    }


    private void OnTriggerEnter2D(Collider2D collision) //se o inimigo for atingido por uma bala ele morre, para de seguir o player e some depois de um tempo
    {
        if (collision.CompareTag("pistolBullet")) //caso seja acertado por uma "PistolBullet"
        {
            lives-= Pistol.PistolDamage; //leva o dano da imposto no script "Pistol", Essa formula pode ser utilizada para adicionar os upgrades de dano
        }
        else if (collision.CompareTag("mgBullet")) //caso seja acertado por uma "MgBullet"
        {
            lives-= MachineGun.MgDamage;//leva o dano da imposto no script "MachineGun"
        }
        else if (collision.CompareTag("shotgunbullet")) //caso seja acertado por uma "MgBullet"
        {
            lives-= Shotgun.ShotgunlDamage;//leva o dano da imposto no script "Shotgun"
        }
        if (lives <= 0) //caso a vida do inimigo chege a 0 ...
            {
                deathFx.Play(); //toca o som de morte
                anim.SetTrigger("Dead"); //Ativa a o trigger de animação 
                Destroy(gameObject.GetComponent<BoxCollider2D>()); //destroi a hitbox para as balas não acertarem os corpos mortos
                isAlive = false; //muda o estado do inimigo para morto
                Destroy(gameObject, 1.5f); //destroy o corpo depois de 1.5 segundos
                Drop();
            }
    }
    
    void enemyMove()
    {
        if (Player!= null && isAlive) //se o player existe ...
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime ); //move o inimigo na direção do player
        }
    }
   


    private void Drop()
    {
        if(Random.Range(0f, 1f) <= 0.3f)
        {
          IntToText.currency += 1;
        }
    }
}
    

