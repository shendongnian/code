    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    public class PlayerShoot : MonoBehaviour {
    
    	public GameObject Ammo; // the shot
    	public GameObject FiredShot;
    	public AudioClip bcgMusic;
    	public List<GameObject> ShotsOnAir;
    
    	//public AudioClip sound1;	// Use this for initialization
    
    	void Start (){
    		ShotsOnAir = new List<GameObject>();
    	}
    
    	//void Update (){
    	//	Fire ();
    	//}
    
    	public  void Fire(){
    		//if (Input.touches ("Fire1")){
    
    		if (Input.touchCount > 0 ){			
    			FiredShot = (GameObject)Instantiate(Ammo,transform.position,transform.rotation);
    			ShotsOnAir.Add(FiredShot);
    			AudioSource.PlayClipAtPoint (bcgMusic, transform.position);
    		}
    
    		if(ShotsOnAir != null){
    			int i=0;
    
    			foreach (GameObject GB in ShotsOnAir){
    
    
    				ShotsOnAir[i].transform.position += ShotsOnAir[i].transform.forward * 10000 * Time.deltaTime;
    
    				i++;
    
    			}
    
    
    		}
    
    	}
    
    
    }
