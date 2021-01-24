    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class BulletListener : MonoBehaviour {
    
    	public Camera mainCamera;
    	public BulletController bulletPrefab;
    
    	void Update () {
    		if (Input.GetMouseButtonDown (0)) {
    
    			//create ray from camera to mousePosition
    			Ray ray = mainCamera.ScreenPointToRay (Input.mousePosition);
    
    			//Create bullet from the prefab
    			BulletController newBullet = Instantiate (bulletPrefab.gameObject).GetComponent<BulletController> ();
    
    			//Make the new bullet start at camera
    			newBullet.transform.position = mainCamera.transform.position;
    
    			//set bullet direction
    			newBullet.SetDirection (ray.direction);
    
    		}
    
    	}
    }
