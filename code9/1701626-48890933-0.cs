    using UnityEngine;
    using System;
    
    public class EventExample : MonoBehaviour {
    	public static event Action myEvent;
    
    	void OnGUI() {
    		if (GUI.Button(new Rect(10f, Screen.height - 40, 100, 30), "next round")) {
    			myEvent();
    		}
    	}
    }
