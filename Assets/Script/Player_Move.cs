using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    Rigidbody2D rigid;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hx = Input.GetAxisRaw("Horizontal");
        float hy = Input.GetAxisRaw("Vertical");

        rigid.AddForce(Vector2.right * hx, ForceMode2D.Impulse);
        //rigid.AddForce(Vector2.left * hx, ForceMode2D.Impulse);
        rigid.AddForce(Vector2.up * hy, ForceMode2D.Impulse);
        //rigid.AddForce(Vector2.down * hy, ForceMode2D.Impulse);
    }
}
