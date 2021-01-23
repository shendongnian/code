    public class NetworkManager : MonoBehaviour {
    
    	public void Start () {
    		RPCApi.Resolve (this);
        }
    
        ...
    
    	[Expose]
    	public void addStar(string system) {
    		Planet fun = JsonUtility.FromJson<Planet> (system);
    		GameObject prefabs = GameObject.Find ("PrefabContainer");
    		PrefabContainer obj = prefabs.GetComponent<PrefabContainer> ();
    		GameObject newobj = Instantiate (obj.star, new Vector3 (fun.x, fun.y, 0), Quaternion.Euler (0, 0, 0));
    		newobj.name = fun.id;
    		newobj.GetComponent<PlanetBehaviour> ().planetConfig = fun;
    	}
    
    	[Expose]
    	public void UpdateStar (string uuid, float x, float y) {
    		GameObject system = GameObject.Find (uuid);
    		MoveToBehaviour move = system.GetComponent<MoveToBehaviour>();
    		move.MoveTo(new Vector3(x, y, 0));
    	}
    }
