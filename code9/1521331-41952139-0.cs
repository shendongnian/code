    using UnityEngine;
    using System.Collections;
    
    public class rotate : MonoBehaviour 
    {
        public string rotate_along = "y";
        public float speed = 10.0f;
        private float _currentAngle = 0.0f;
        private float _targetAngle = 45.0f;
    
        // Use this for initialization
        void Start () 
        {
        }
    
        // Update is called once per frame
        void Update () 
        {
            if (_currentAngle == _targetAngle)
                return;
            float angle = speed * Time.deltaTime
            if (_currentAngle + angle > _targetAngle)
                angle = _targetAngle - _currentAngle;
    
            if (rotate_along == "y") 
            {
                this.transform.Rotate (0, angle, 0);
            } 
            else if (rotate_along == "x") 
            {
                this.transform.Rotate (angle, 0, 0);
            } else if (rotate_along == "z") 
            {
                this.transform.Rotate (0, 0, angle);
            } 
            else 
            {
                print ( "please! check your cordinate for rotating for "+gameObject.name );
            }
            _currentAngle += angle;
         }
    }
