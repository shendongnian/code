    public class rotateX : MonoBehaviour
    {
        public float sensitivityVert = 9.0f;
    
        private float rotationX = 0;
        public float minimumVert = -45.0f;
        public float maximumVert = 45.0f;
    
    	Vector3 initial;
    
        void Start()
        {
            initial = transform.localEulerAngles;
        }
    	    
    	// OnMouseDown is called when the user has pressed the 
        // mouse button while over the GUIElement or Collider.
    	protected void OnMouseDown()
    	{
    	    sign = -sign;
    	}
    	float sign = -1f;
    	    
        void Update()
        {
    	    rotationX += sign * Input.GetAxis("Mouse Y") * sensitivityVert;
            //rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);
    
            transform.localEulerAngles = new Vector3(rotationX, initial.y, 0f);
        }
    }
