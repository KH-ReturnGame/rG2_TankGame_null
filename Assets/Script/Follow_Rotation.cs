using UnityEngine;

public class Follow_Rotation : MonoBehaviour
{
    public GameObject target;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // Follow Tank_1_Body.transform.rotation
        target = GameObject.Find("Tank_1_Body_0");
        if (target != null)
        {
            transform.rotation = target.transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
