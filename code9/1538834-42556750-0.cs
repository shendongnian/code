     using UnityEngine;
     using System.Collections;
    public class PlayAnimation : MonoBehaviour {
	public Animator animator;
	byte idle=0;
	byte walk=1;
	byte sprint=2;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			animator.SetInteger ("Anumber", walk);
		} else if (Input.GetKey (KeyCode.A)) {
			animator.SetInteger ("Anumber", walk);
		} else if (Input.GetKey (KeyCode.S)) {
			animator.SetInteger ("Anumber", walk);
		} else if (Input.GetKey (KeyCode.D)) {
			animator.SetInteger ("Anumber", walk);
		} else {
			animator.SetInteger ("Anumber", idle);
		}
	}
        }
