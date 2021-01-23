    using UnityEngine;
    using System.Collections;
    
    public class Test : MonoBehaviour {
    	public Quaternion x;
    	// Use this for initialization
    	void Start () {
    		x = transform.rotation;
    	}
    	
    	// Update is called once per frame
    	void Update () {
    		transform.rotation = x;
    	}
    }
