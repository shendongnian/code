    using UnityEngine;
    
    public class CubeController : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        public float Force = 10;
    
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    
        private void FixedUpdate()
        {
            ForceMode? forceMode = null;
    
            if (Input.GetKeyDown(KeyCode.W)) // normal
                forceMode = ForceMode.Force;
            else if (Input.GetKeyDown(KeyCode.S)) // dash
                forceMode = ForceMode.Impulse;
    
            if (forceMode.HasValue)
                _rigidbody.AddRelativeForce(Vector3.forward*Force, forceMode.Value);
        }
    }
