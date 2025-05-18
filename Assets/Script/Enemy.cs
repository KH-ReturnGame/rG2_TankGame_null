using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    public int maxHealth = 100;
    private int curHealth;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Invoke("Think", 5);
        // Invoke with delay 
    }

    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move
        rigid.linearVelocity = new Vector2(nextMove, rigid.linearVelocity.y);
        // Platform Check
        if(nextMove == 1)
        {
            Vector2 frontVec = new Vector2(rigid.position.x + nextMove - 1, rigid.position.y);
            Debug.DrawRay(frontVec, Vector3.right, new Color(0, 1, 0));
            RaycastHit2D rayHitR = Physics2D.Raycast(frontVec, Vector3.right, 1, LayerMask.GetMask("Platform"));
            if (rayHitR.collider != null)
            {
                nextMove = nextMove * -1;
                CancelInvoke();
                Invoke("Think", 5);
            }
        }
        if(nextMove == -1)
        {
            // Avoid collision
            Vector2 frontVec = new Vector2(rigid.position.x + nextMove + 1, rigid.position.y);
            Debug.DrawRay(frontVec, Vector3.left, new Color(0, 1, 0));
            RaycastHit2D rayHitL = Physics2D.Raycast(frontVec, Vector3.left, 1, LayerMask.GetMask("Platform"));
            if (rayHitL.collider != null)
            {
                nextMove = nextMove * -1;
                CancelInvoke();
                Invoke("Think", 5);
            }
        }
    }
    void Think()
    {
        nextMove = Random.Range(-1, 2);
        Invoke("Think", 5);
        // Reflexive
    }

    // Damage
    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        Debug.Log("Enemy Health: " + "-" + damage + "->" + curHealth);

        if(curHealth <= 0)
        {
            Die();
            Debug.Log("Enemy is destroyed");
        }
    }

    // Destroy
    void Die()
    {
        Destroy(gameObject);
    }
}
