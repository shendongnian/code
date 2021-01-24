    using System.Collections;
    using UnityEngine;
        
    public class LightRotator : MonoBehaviour
    {
        public Vector3 RotationAxis = Vector3.right;
    
        Quaternion _startRotation;
        float _rotationIncrement = 0;
        void Start()
        {
             _startRotation = transform.rotation;
        }
        void Update ()
        {
            Quaternion rotationMod = 
                Quaternion.AngleAxis(_rotationIncrement, RotationAxis);
            _rotationIncrement += 1;
            transform.rotation = _startRotation * rotationMod;
        }
    }
