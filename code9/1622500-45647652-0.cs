    using UnityEngine;
     
    public class Timer : MonoBehaviour 
    {
    	public float waitTime = 1f;
     
    	float timer;
     
    	void Update () 
    	{
    		timer += Time.deltaTime;
    		if (timer > waitTime) { 
                if (Application.internetReachability == NetworkReachability.NotReachable) {
                    Debug.Log ("No internet access");
                } else {
                    Debug.Log ("internet connection");
                }
    			timer = 0f;
    		}
    	}
    }
