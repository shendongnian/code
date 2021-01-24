    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    public class keepingScore : MonoBehaviour {
        public static double homeScore;
        Text text;
	    void Awake () {
            text = GetComponent<Text>();
            homeScore = 0.0;
	    }
	
	    // Update is called once per frame
	    void Update () {
            text.text = "Score: " + homeScore;
	
	    }
    }
