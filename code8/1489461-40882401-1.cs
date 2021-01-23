    using UnityEngine;
    using System.Collections;
 
    public class GameManager : MonoBehaviour {
 
    public static GameManager instance = null;
 
    private bool triggerredOccurred = false;
 
    public bool IsTriggerredOccurred {
        get { return triggerredOccurred;}
    }
 
    public void TriggerredOccurred() {
        triggerredOccurred = true;
    }
 
    void Awake(){
        if (instance == null) { //check if an instance of Game Manager is created
            instance = this;    //if not create one
        } else if (instance != this) {
            Destroy(gameObject);    //if already exists destroy the new one trying to be created
        }
 
        DontDestroyOnLoad(gameObject);  //Unity function allows a game object to persist between scenes
    }
 
    // Use this for initialization
    void Start () {
     
    }
     
    // Update is called once per frame
    void Update () {
     
        }
    }
