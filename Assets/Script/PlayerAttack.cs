using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    public float cooltime;
    bool canshot = true;
    private float curtime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKey("space") && canshot)
            {
                Instantiate(bullet, pos.position, transform.rotation);
                StartCoroutine("Delay");
            canshot = false;
            }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        canshot = true;
    }
}
