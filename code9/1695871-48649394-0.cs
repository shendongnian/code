    using UnityEngine;
    
    public class RotateObj : MonoBehaviour
    {
        private void Update()
        {
            // rotate to its own axis
            transform.Rotate(new Vector3(Random.value, Random.value, Random.value)); 
            
            // rotate about axis passing through the point in world coordinates
            transform.RotateAround(Vector3.zero, Vector3.up, 1.0f); 
        }
    }
