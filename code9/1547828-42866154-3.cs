    using UnityEngine;
    
    public class rotate : MonoBehaviour {
    
        public float speed = 100.0f;
        Vector3 angle;
        float rotation = 0f;
        public enum Axis
        {
            X,
            Y,
            Z
        }
        public Axis axis = Axis.X;
        public bool direction = true;
    
        void Start()
        {
            angle = transform.localEulerAngles;
        }
    
        void Update()
        {
            rotation += speed * Time.deltaTime;
            if (rotation >= 360f) 
                rotation -= 360f; // keep it to a value of 0 to 359.99...
            switch(axis)
            {
                case Axis.X:
                    angle.x = Rotation();
                    break;
                case Axis.Y:
                    angle.y = Rotation();
                    break;
                case Axis.Z:
                    angle.z = Rotation();
                    break;
            }
            transform.localEulerAngles = angle;
        }
    
        float Rotation() { return direction ? rotation : -rotation; }
    }
