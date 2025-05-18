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
            Debug.LogError("�� ������Ʈ�� �θ� �����ϴ�!");
            return;
        }

        parentRenderer = transform.parent.GetComponent<SpriteRenderer>();
        myRenderer = GetComponent<SpriteRenderer>();

        if (parentRenderer == null || myRenderer == null)
        {
            Debug.LogError("SpriteRenderer�� �����ϴ�!");
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
