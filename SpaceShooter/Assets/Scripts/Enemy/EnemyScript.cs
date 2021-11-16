using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 5f;
    public float rotate_speed = 50f;

    public bool canShoot;
    public bool canRotate;
    private bool canMove = true;

    public float bound_x = -11f;

    
    public GameObject Enemy_Bullet;
    
    public Transform attack_point;

    public UnityEngine.Animator anim;
    private AudioSource explosionSound;

    public float attack_timer = 5f;
    private float current_Attack_Timer;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();

        
    }

     void start()
    {

        current_Attack_Timer = attack_timer;
        
        if(canRotate){
           if(Random.Range(0,2) > 0){
               rotate_speed = Random.Range(rotate_speed, rotate_speed + 20f);
               rotate_speed *= -1f;
           } else {
               rotate_speed = Random.Range(rotate_speed, rotate_speed + 20f);
           }
        }

        // if(canShoot){
        //     Invoke("StartShooting", Random.Range(1f, 3f));
        // }
        
    
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateEnemy();
        
        if(canShoot){
                canShoot = false;
                attack_timer= 0f;
                Invoke("StartShooting", Random.Range(1f, 3f));
        }

    }

    void Move(){
        if(canMove){
            Vector3 temp =transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

            if(temp.x < bound_x)
                gameObject.SetActive(false);
        }
    }

    void RotateEnemy(){
        if(canRotate){
            transform.Rotate(new Vector3(0f, 0f, rotate_speed * Time.deltaTime), Space.World);
        }
    }

     void StartShooting(){
        attack_timer += Time.deltaTime;
        if(attack_timer > current_Attack_Timer){
            canShoot = true;
            
        }
        GameObject bullet = Instantiate(Enemy_Bullet, attack_point.position, Quaternion.Euler(0f, 0f, 0f));
        //bullet.GetComponent<BulletScript>().is_EnemyBullet=true;
            if(canShoot){
                Invoke("StartShooting", Random.Range(1f, 3f));
                canShoot = false;
                attack_timer= 0f;
                
             }

            
    }

    void TurnOfGameObject(){
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "Bullet"){
            canMove=false;

            if(canShoot==true){
            canShoot = false;
            CancelInvoke("StartShooting");
            }
            
            canShoot = false;
            CancelInvoke("StartShooting");

            Invoke("TurnOfGameObject", 0.9f);
            explosionSound.Play();
            anim.Play("Destroy");

            
            
        }
    }
}
