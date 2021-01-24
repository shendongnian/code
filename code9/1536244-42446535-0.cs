    using UnityEngine;
    using System.Collections;
    //Add this class to your world game object and store your globals here
    public class GlobalContext : MonoBehaviour{
    }
    public class BaseClass : MonoBehaviour {
        private GlobalContext world;
        void Start() {
            //find the cabinet object in your scene
            world= transform.root.GetComponent<GlobalContext>();
        }
    }
