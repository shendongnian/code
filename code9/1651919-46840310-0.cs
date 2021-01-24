    using UnityEngine;
    
    public class ExampleClass : MonoBehaviour {
        void OnBecameInvisible() {
            enabled = false;
        }
        void OnBecameVisible() {
            enabled = true;
        }
    }
