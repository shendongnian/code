    using UnityEngine;
    
    public class RotateAround : MonoBehaviour {
    
    	public Transform pivot;
        public float degreesPerSecond;
    	
    	void Update () {
            transform.RotateAround(pivot.position, Vector3.up, degreesPerSecond * Time.deltaTime);
        }
    }
