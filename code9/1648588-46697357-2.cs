    using UnityEngine;
    
    public class LookAtTarget : MonoBehaviour {
        
        //assign in inspector
        public Collider floor;
    
        //make sure you Camera is taged as MainCamera, or make it public and assign in inspector
        Camera mainCamera;
        RaycastHit rayHit;
        //not needed when assigned in the inspector    
        void Start() {
            mainCamera = Camera.main;
        }
    
        void Update () {
    		
            if(Input.GetMouseButtonUp(0)) {
    
                if(floor.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity)) {
                    //its actually the inverse of the lookDirection, but thats is because the rotation around z later.
                    Vector3 lookDirection = transform.position - rayHit.point;
    
                    float angle = Vector3.Angle(lookDirection, transform.forward);
    
                    transform.rotation = Quaternion.AngleAxis(Vector3.Dot(Vector3.right, lookDirection) > 0 ? angle : angle * -1, Vector3.forward);
    
                } 
    
            }
    
    	}
    }
