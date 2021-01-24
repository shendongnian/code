    public class MapDetect : MonoBehaviour {
    	
    	private bool isTriggered;
    
    	void OnTriggerEnter(Collider other)
    	{
    		if (other.gameObject.CompareTag("Player"))
    			isTriggered = true;
    	}
    	
    	void OnTriggerExit(Collider other)
    	{
    		if (other.gameObject.CompareTag("Player"))
    			isTriggered = false;
    	}
    	
    	void Update(){
    		if(Input.GetKey(KeyCode.Space)){
    			Debug.Log(isTriggered);
    		}
    	}
    }
