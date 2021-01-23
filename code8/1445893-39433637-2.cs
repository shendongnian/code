    using UnityEngine;
    using System.Collections;
    
    public class star : MonoBehaviour {
    GameObject[] pauseObjects;
    
    public float timer = 7;
    
    float t = 0;
    bool pause = false;
    
    void Start () {
        pauseObjects = GameObject.FindGameObjectsWithTag("Player");
        t = timer;
    }
    	
    
    
    void Update() {
        if(pause){
            if(t<0){
                t=timer;
                pause = false;
                time.timescale = 1;
            }else{
                t -= Time.deltaTime;
                time.timescale = 0;
            }
        }
    }
