using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    SpriteRenderer sprite;
    public AudioSource shootFx;
    public GameObject Bullet;
    public Transform spawnBullet;
    public static int PistolDamage = 3; //dano causado  quando a "PistolBullet" acertar os inimigos
    public static float PistlfireRate = 0.40f; //variavel acessivel de outros scripts que muda a cadencia de disparo da
    public static float PistolbulletRange = 0.4f; //variavel acessivel de outros scripts que muda o range da arma
    private float canFire = -1f; //variavel usada no comando de fire rate
   
    
    // Start is called before the first frame update


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Aim(); //função para fazer a arma apontar para o mouse
        tiro(); //função que faz o mouse atirar
    }

    void tiro()
    {   
        if (Input.GetKey(KeyCode.Mouse0)&&(Time.time > canFire)) //usa o botão m1 para atirar e verifica o se o player pode atirar
        {
            canFire = Time.time + PistlfireRate; //funciona como millis do arduino
            Instantiate(Bullet, spawnBullet.position, transform.rotation); //spawna a bala no game object SpawnBullet que esta dentro do objeto da arma
            shootFx.Play(); //toca o som de tiro
        }
    }

    void Aim()
    {
        Vector3 mousePos = Input.mousePosition; //pega a posiçao do maouse
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position); //pega a posição global da camera
        Vector2 offset = new Vector2 (mousePos.x - screenPoint.x, mousePos.y - screenPoint.y); //calcula a diferença entre o mouse e a camera

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg; //transforma o offset em um par de ordenadas
        transform.rotation = Quaternion.Euler(0,0,angle);   //setar o valor de rotação da arma

        sprite.flipY = (mousePos.x < screenPoint.x); //caso a arma esteja a esquerda do personagem ela não fica de cabeça pra baixo
    }
    
}
