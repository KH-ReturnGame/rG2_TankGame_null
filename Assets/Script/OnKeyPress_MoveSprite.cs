using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class OnKeyPress_MoveSprite : MonoBehaviour
{
    public float speed = 2;
    //public float rotateSpeed = 50f;
    float vx = 0;
    float vy = 0;
    bool leftFlag = false;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    public float maxHealth = 100;
    public float curHealth;

    public GameManager gameManager;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid.gravityScale = 0;
        //rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        vx = 0;
        vy = 0;

        //이동 방향 및 속도 결정
        if(Input.GetKey("right"))
        {
            vx = speed;
            leftFlag = false;
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if(Input.GetKey("left"))
        {
            vx = -speed;
            leftFlag = true;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (Input.GetKey("up"))
        {
            vy = speed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if(Input.GetKey("down"))
        {
            vy = -speed;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if(Input.GetKey("left") && Input.GetKey("up"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        if(Input.GetKey("right") && Input.GetKey("up"))
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);
        }
        if (Input.GetKey("left") && Input.GetKey("down"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 135);
        }
        if (Input.GetKey("right") && Input.GetKey("down"))
        {
            transform.rotation = Quaternion.Euler(0, 0, -135);
        }
    }

    void FixedUpdate()
    {
        //이동
        rigid.linearVelocity = new Vector2(vx, vy);

        this.GetComponent<SpriteRenderer>().flipX = leftFlag;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 적과 충돌
        if (collision.gameObject.tag == "Enemy_2")
        {
            OnDamaged(collision.transform.position);
            TakeDamage(10);
        }
        if (collision.gameObject.tag == "Enemy_1")
        {
            TakeDamage(9999);
        }
        // Finish_Point
        //if (collision.gameObject.tag)
        //{
        //    gameManager.NextStage();
        //    Debug.Log("Finish, next stage");
        //}
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Finish_Point
        if (collider.CompareTag("Finish"))
        {
            gameManager.NextStage();
            Debug.Log("Finish, next stage");
        }
    }

    void OnDamaged(Vector2 targetPos)
    {
        // 적과 충돌 시 무적 시간
        gameObject.layer = 8;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f); 
        int dircX = transform.position.x - targetPos.x > 0 ? 1 : -1;
        int dircY = transform.position.y - targetPos.y > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dircX, dircY) * 7, ForceMode2D.Impulse);

        Invoke("OffDamaged", 3);
    }

    public void TakeDamage(float damage)
    {
        curHealth -= damage;
        Debug.Log("Player Health: " + "-" + damage + "->" + curHealth);

        if (curHealth <= 0)
        {
            gameManager.GameOver();
        }
    }

    void OffDamaged()
    {
        // 무적 시간 해제
        gameObject.layer = 3;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
