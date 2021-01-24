     using UnityEngine;
     using System.Collections;
    public class CardMovement : MonoBehaviour {
	public RectTransform rectangle;
	// Use this for initialization
	void Start () {
		rectangle = GetComponent<RectTransform> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		 
		if (rectangle.rect.Contains (Input.GetTouch (0).deltaPosition)){
			Vector2 V = new Vector2 (0.125f, 0.125f);
			transform.position = V;
			
		}
	
	}
    }
