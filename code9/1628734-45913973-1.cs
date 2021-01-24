    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class Astroid : MonoBehaviour {
    	//I need to be able to set this variable to a material
    	//public Material mat;
    	// Use this for initialization
    	void Start () {
    		this.GetComponent<SphereCollider>().enabled = false;
    		StartCoroutine("Change");
    	}
    	// Update is called once per frame
    	void Update () {
    		
    	}
    	IEnumerator Change(){
    		yield return new WaitForSeconds (3);
    		this.GetComponent<SphereCollider>().enabled = true;
    		this.GetComponent<Renderer> ().material = Spawner.mat2;
    	}
    }
