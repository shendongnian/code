    using UnityEngine;
    
    public class MoveTarget : MonoBehaviour
    {
        // Drag & Drop the camera you want to move
        public Transform Target ;
    
        // Specify the movement you want to apply
        public Vector3 movement = new Vector3( 0, 4, 0 ) ;
    
        private void Start()
        {
             // Automatically retrieve the Camera tagged "MainCamera" if no target specified
             if( Target == null )
                 Target = Camera.main.GetComponent<Transform>();
        }
    
        private void Update()
        {
             if( Target == null )
                Debug.LogError("No target specified !");
             else
                 Target.Translate( movement * Time.deltaTime, Space.World ) ;
        }    
    }
