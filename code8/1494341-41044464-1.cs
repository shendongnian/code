    public class FanoutObj : MonoBehaviour
    {
        public float distMult = 1f;
        Vector3 baseToParent;
    	
    	void Start ()
        {       
            baseToParent = transform.localPosition;
    
    	}	
    
    	void Update ()
        {
            distMult += Input.GetAxis("Mouse ScrollWheel") * 0.4f;//speed of scrolling
            transform.localPosition = (baseToParent * distMult);
    	}
    }
