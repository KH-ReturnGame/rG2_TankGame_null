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
        //���� �ð� �� Bullet �ı�
        Invoke("DestroyBullet", 2);
    }

    // Update is called once per frame
    void Update()
    {
        //�̵�
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.up, distance, isLayer);
        if(ray.collider != null)
        {
            EnemyMove enemy = ray.collider.GetComponent<EnemyMove>();
            if(ray.collider.tag == "Enemy_1" || ray.collider.tag == "Enemy_2")
            {
                Debug.Log("����!!");
                enemy.TakeDamage(40);
            }
            DestroyBullet();
        }
    }

    //�ı�
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
