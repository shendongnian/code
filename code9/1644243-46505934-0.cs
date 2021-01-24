    public class TestDestroy_NonCrashing : MonoBehaviour {
    	public GameObject someObj; //assigned in the inspector
    	
    	void Start () {
    		Destroy(someObj);
    		Debug.Log(someObj); //prints "Cube (UnityEngine.GameObject)"
    		MeshRenderer someComponent = someObj.GetComponent<MeshRenderer>();
    		someComponent.material.SetColor("_Color", new Color(1, 0, 0));
    	}
    }
    public class TestDestroy_Crashing : MonoBehaviour {
    	public GameObject someObj; //assigned in the inspector
    	
    	void Start () {
    		Destroy(someObj);
    	}
    
    	void Update() {
    		Debug.Log(someObj);  //prints "null"
    		MeshRenderer someComponent = someObj.GetComponent<MeshRenderer>();
    		someComponent.material.SetColor("_Color", new Color(1, 0, 0));
    	}
    }
