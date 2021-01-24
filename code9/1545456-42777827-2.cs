    using UnityEngine;
    using System.Collections;
    
    public class CollisionAndtheMovement : MonoBehaviour {
    	public float speed;
    	public bool  toRight;`enter code here`
    	// Use this for initialization
    	void Start () {
    		toRight = true;
    
    
    	}
    	
    	// Update is called once per frame
    	void Update (){
    		if (toRight) {
    			transform.Translate (Vector2.right*Time.deltaTime*speed, 0);
    		}
    
    		if (!toRight) {
    			transform.Translate (Vector2.left*Time.deltaTime*speed, 0);
    		}
    			
    	}
    
    	void OnCollisionEnter2D(Collision2D col){
    		if (col.gameObject.tag == "Crate" && toRight) {
    			toRight = false;
    		} else {
    			toRight = true;
    		}
    	}
    }
