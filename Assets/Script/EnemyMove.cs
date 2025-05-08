using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Invoke("Think", 5);
        //5초 딜레이를 두고 Think() 호출
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
                //Debug.Log("충돌 주의! 충돌 주의!");
                nextMove = nextMove * -1;
                CancelInvoke();
                Invoke("Think", 5);
            }
        }
        if(nextMove == -1)
        {
            Vector2 frontVec = new Vector2(rigid.position.x + nextMove + 1, rigid.position.y);
            Debug.DrawRay(frontVec, Vector3.left, new Color(0, 1, 0));
            RaycastHit2D rayHitL = Physics2D.Raycast(frontVec, Vector3.left, 1, LayerMask.GetMask("Platform"));
            if (rayHitL.collider != null)
            {
                //Debug.Log("충돌 주의! 충돌 주의!");
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
        //재귀
    }

}
