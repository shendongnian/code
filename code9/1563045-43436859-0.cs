        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        
        public class multipleObjectsGrandes : MonoBehaviour
        {
    
    	public GameObject prefabGrandes;
    
    	public GameObject[] cuerpos;
    	public int cantidad;
    	public float minScaleObj;
    	public float maxScaleObj;
    
    	public float escalaMax;
    
    	void Awake ()
    	{
    		cuerpos = new GameObject[cantidad];
    		for (int i = 0; i < cuerpos.Length; i++) {
    
    			//Position
    			Vector3 position = new Vector3 (Random.Range (-40.0f, 40.0f), Random.Range (-40.0f, 40.0f), Random.Range (-40.0f, 40.0f));
    
    			GameObject clone = (GameObject)Instantiate (prefabGrandes, position, Quaternion.identity);
    
    			//Scale
    			clone.transform.localScale = Vector3.one * Random.Range (minScaleObj, maxScaleObj);
    
    			//Rotation
    			clone.transform.rotation = Quaternion.Euler (Random.Range (0.0f, 360.0f), Random.Range (0.0f, 360.0f), Random.Range (0.0f, 360.0f));
    
    			escalaMax = clone.transform.localScale.x;
    
    			//Debug.Log(escalaMax);
    
        		}
        	}
        }
