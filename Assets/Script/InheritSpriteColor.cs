using UnityEngine;

public class InheritSpriteColor : MonoBehaviour
{
    SpriteRenderer parentRenderer;
    SpriteRenderer myRenderer;
    // Follow parent's renderer
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (transform.parent == null)
        {
            Debug.LogError("이 오브젝트는 부모가 없습니다!");
            return;
        }

        parentRenderer = transform.parent.GetComponent<SpriteRenderer>();
        myRenderer = GetComponent<SpriteRenderer>();

        if (parentRenderer == null || myRenderer == null)
        {
            Debug.LogError("SpriteRenderer가 없습니다!");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (parentRenderer != null && myRenderer != null)
        {
            myRenderer.color = parentRenderer.color;
        }
    }
}
