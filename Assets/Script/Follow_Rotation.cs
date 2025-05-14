using UnityEngine;

public class Follow_Rotation : MonoBehaviour
{
    public GameObject target;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        target = GameObject.Find("Tank_1_Body_0");
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            transform.rotation = target.transform.rotation;
        }
    }
}
