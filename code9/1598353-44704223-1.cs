    using UnityEngine;
    public class TweenTest : MonoBehaviour {
    
    	float myFloat = 0;
    	Vector3 myVector = Vector3.zero;
    	Tween myTween;
    		
    	void Start () {
    		myTween = new Tween(ref myFloat, ref myVector);		
    		Debug.Log(myFloat);
    		Debug.Log(myVector);
    	}
    }
