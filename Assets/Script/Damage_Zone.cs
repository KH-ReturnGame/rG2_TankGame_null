using System.Collections;
using UnityEngine;

public class Damage_Zone : MonoBehaviour
{
    public float effectRadius = 5f; // 중심으로부터 최대 반경
    public float damageInterval = 1f;
    public float maxDamage = 10f;
    public float minDamage = 2f;

    private Coroutine damageCoroutine;
    public Transform player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            damageCoroutine = StartCoroutine(ApplyDotDamage());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
            player = null;
        }
    }

    IEnumerator ApplyDotDamage()
    {
        while (true)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            float t = distance / effectRadius;
            t = Mathf.Clamp01(t);
            float damage = Mathf.Lerp(maxDamage, minDamage, t);

            OnKeyPress_MoveSprite playerScript = player.GetComponent<OnKeyPress_MoveSprite>();
            if (playerScript != null)
            {
                playerScript.TakeDamage(damage);
                Debug.Log($"플레이어 거리: {distance:F2}, 데미지: {damage:F2}");
            }

            yield return new WaitForSeconds(damageInterval);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
