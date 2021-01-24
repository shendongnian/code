    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class Senes : MonoBehaviour {
    public SpriteCColor A;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision collision)
    {
      A = collision.gameObject.GetComponent<SpriteCColor>();
        if (A.index == 1)
        {
            Debug.Log("Red");
        }
        else if (A.index == 2)
        {
            Debug.Log("Yellow");
        }
        else if (A.index == 3)
        {
            Debug.Log("Green");
        }
        else if (A.index == 4)
        {
            Debug.Log("Blue");
        }
    }
    }
