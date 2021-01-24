    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class PlayerMover : MonoBehaviour {
    	public float speed;
	    private Rigidbody rb;
	    void Start () {
	    	rb = GetComponent<Rigidbody>();
	    }
	    void Update () {
		    bool w = Input.GetKey(KeyCode.W);
		    if (w) {
			    Vector3 move = new Vector3(0, 0, 1) * speed;
			    rb.MovePosition(move);
		    	Debug.Log("Moved using w key");
		    }
	    }
    }
