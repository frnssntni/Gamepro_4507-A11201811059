using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    public float speed = 5f;
    public float min_y,max_y;

    [SerializeField]
    private GameObject player_Bullet;
    [SerializeField]
    private Transform attack_Point;

    public float attack_timer = 0.3f;
    private float current_Attack_Timer;
    public bool canAttack;
    public bool canShoot;

    public UnityEngine.Animator anim;
    private AudioSource shotaudio;

    void Awake(){
        shotaudio = GetComponent<AudioSource>();
    }
    void Start()
    {
        current_Attack_Timer = attack_timer;
        anim = GetComponent<Animator>();
        if(canShoot){
            Invoke("StartShooting", Random.Range(1f, 3f));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Attack();
    }

    void MovePlayer(){
        if(Input.GetAxisRaw("Vertical") > 0f) {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;

            if(temp.y > max_y)
                temp.y=max_y;
            
            transform.position = temp;

        } 
        else if (Input.GetAxisRaw("Vertical") < 0f) {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;

             if(temp.y < min_y)
                temp.y=min_y;
            
            transform.position = temp;
        }
    }

    void Attack() {
        attack_timer += Time.deltaTime;
        if(attack_timer > current_Attack_Timer){
            canAttack = true;
        }
        if(Input.GetKeyDown(KeyCode.K)) {
            if(canAttack){
                canAttack = false;
                attack_timer= 0f;
                Instantiate(player_Bullet, attack_Point.position, Quaternion.identity);
                shotaudio.Play();
            }
            
        }
    }

    void TurnOfGameObject(){
        gameObject.SetActive(false);
    }

    void mati(){
        SceneManager.LoadScene("Menu");
    }

     void OnTriggerEnter2D(Collider2D target){
       if( target.tag == "Enemy"){
        
            if(canAttack){
                canAttack = false;
            }

            Invoke("TurnOfGameObject", 5f);
            anim.Play("Destroy");
            Invoke("mati",5f);
        }
    }

    void StartShooting(){
        GameObject bullet = Instantiate(player_Bullet, attack_Point.position, Quaternion.Euler(0f, 0f, 0f));

        if(canShoot){
                Invoke("StartShooting", Random.Range(1f, 3f));
        }
            
    }

}
