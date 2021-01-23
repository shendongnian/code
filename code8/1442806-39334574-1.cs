    using UnityEngine;
    using System.Collections;
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class RocketController : MonoBehaviour {
    
    // Use this for initialization
    Rigidbody2D rd;
    void Start () {
    
        rd = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update () {
    
        if(rd == null)
            return;
        if(Input.GetKey("right"))
        {
            rd.velocity = new Vector2(1,0);
        }
        else if(Input.GetKey("left"))
        {
            rd.velocity = new Vector2(-1,0);
        }
        else
        {
            rd.velocity = new Vector2(0,0);
        }
    
    
      }//close update
    }
