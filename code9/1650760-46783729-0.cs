    using UnityEngine;
    using System.Collections;
    
    public class drag : MonoBehaviour {
    	public bool gameStart = false;
    	public float maxXValue = 9f;
    	public float speed = 1.0f;
    	Vector3 dist;
    	float posX;
    	float posY;
    
    
    	void OnMouseDown(){
    		dist = Camera.main.WorldToScreenPoint(transform.position);
    		posX = Input.mousePosition.x - dist.x;
    		posY = Input.mousePosition.y - dist.y;
    	}
    
    	void OnMouseDrag(){
    
    		Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);  
    		Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
    
    		if (gameStart == false) {
    			worldPos.x = Mathf.Clamp (worldPos.x, -5f, 5f);
    			worldPos.y = Mathf.Clamp (worldPos.y, -13.2f, -13.2f);
    		} else {
    			worldPos.x = Mathf.Clamp (worldPos.x, -maxXValue, maxXValue);
    			worldPos.y = Mathf.Clamp (worldPos.y, -17.2f, -13.2f);
    		}
    
    		//transform.position = worldPos;
    		transform.position = Vector3.Lerp(transform.position,worldPos,speed*Time.deltaTime);
    	}
    }
