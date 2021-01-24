    using UnityEngine;
    
    public class ColorSelector : MonoBehaviour {
    
        public int index;
    
        void OnMouseDown() {
            Debug.Log(string.Format("Color with index {0} was clicked.", index));
        }
    
    }
