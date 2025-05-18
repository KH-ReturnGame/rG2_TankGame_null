using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask isLayer;
    GameObject target;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //일정 시간 후 Bullet 파괴
        Invoke("DestroyBullet", 2);
    }

    // Update is called once per frame
    void Update()
    {
        //이동
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.up, distance, isLayer);
        if(ray.collider != null)
        {
            EnemyMove enemy = ray.collider.GetComponent<EnemyMove>();
            if(ray.collider.tag == "Enemy_1" || ray.collider.tag == "Enemy_2")
            {
                Debug.Log("명중!!");
                enemy.TakeDamage(40);
            }
            DestroyBullet();
        }
    }

    //파괴
    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.CompareTag("Enemy"))
    //    {
            
    //    }
    //}
}
