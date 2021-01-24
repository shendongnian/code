    using UnityEngine;
    using System.Collections;
    
    public class Return : MonoBehaviour
    {
    
    Vector3 originalPos;
    
    void Start()
    {
        originalPos = new Vector3(75f, -.01f);
    
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Return")
        {
            transform.position = originalPos;
        }
    
    }
    }    
