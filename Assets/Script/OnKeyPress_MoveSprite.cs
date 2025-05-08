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

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid.gravityScale = 0;
        //rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        vx = 0;
        vy = 0;

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
        rigid.linearVelocity = new Vector2(vx, vy);

        this.GetComponent<SpriteRenderer>().flipX = leftFlag;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            OnDamaged(collision.transform.position);
        }
    }

    void OnDamaged(Vector2 targetPos)
    {
        gameObject.layer = 8;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f); 
        int dircX = transform.position.x - targetPos.x > 0 ? 1 : -1;
        int dircY = transform.position.y - targetPos.y > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dircX, dircY) * 7, ForceMode2D.Impulse);

        Invoke("OffDamaged", 3);
    }

    void OffDamaged()
    {
        gameObject.layer = 3;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
