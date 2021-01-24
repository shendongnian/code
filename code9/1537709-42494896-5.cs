    Using UnityEngine;
    public delegate void RockDelegate(Vector2 vel);
    
    public class Generator : MonoBehaviour {
    
    	public static event RockDelegate rockDelegate;
    
    	public GameObject rocks;
    	Vector2 Actualvel, Easyvel, Mediumvel, Hardvel;
    	float Difficulty = 1.5f;
    
    	void Start(){
    		InvokeRepeating("CreateObstacle", 1f, Difficulty);
    		Easyvel = new Vector2(-4, 0);
    		Mediumvel = new Vector2(-8,0);
    		Hardvel = new Vector2(-12, 0);
    		Actualvel = Mediumvel; //<- Here you assign the starting velocity before any Button is pressed
    	}
    
    	void CreateObstacle() {
    		GameObject rock = Instantiate(rocks) as GameObject;
    		rock.GetComponent<Rock>().velocitypublic = Actualvel;
    	}
    
    	void OnGUI() {
    		if (GUI.Button(new Rect(600, 10, 50, 30), "Easy")) {
    			Difficulty = 1.5f;
    			rockDelegate(Actualvel = Easyvel);
    		}
    
    		if (GUI.Button(new Rect(600, 40, 50, 30), "Medium")) {
    			Difficulty = 1f;
    			rockDelegate(Actualvel = Mediumvel);
    		}
    
    		if (GUI.Button(new Rect(600, 70, 50, 30), "Hard")) {
    			Difficulty = 0.5f;
    			rockDelegate(Actualvel = Hardvel);
    		}
    	}
    }
