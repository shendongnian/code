    public class MapDetect : MonoBehaviour {
    	
    	private bool isTriggered;
    
    	void OnTriggerEnter(Collider other)
    	{
    		if (other.gameObject.tag == "Player")
    			isTriggered = true;
    	}
    	
    	void OnTriggerExit(Collider other)
    	{
    		if (other.gameObject.tag == "Player")
    			isTriggered = false;
    	}
    	
    	void Update(){
    		if(Input.GetKey(KeyCode.Space)){
    			Debug.Log(isTriggered);
    		}
    	}
    }
