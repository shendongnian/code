	public Material color002;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// This will get the OBJECT to CHANGE COLOR on KEY PRESS
		if (Input.GetKeyDown (KeyCode.R)) {
			GetComponent<Renderer> ().material.color = Color.red;
			Debug.Log ("R Key Press For RED");
		// This will get the OBJECT to CHANGE MATERIAL on KEY PRESS
		} else if (Input.GetKeyDown (KeyCode.P)) {
			GetComponent<Renderer> ().material = color002;
			Debug.Log ("P Key Press For Pink Material (color002)");
		}
	}
	// This will get the OBJECT to CHANGE COLOR if the FPS Controller collides with Cube GameObject
	void OnTriggerEnter(Collider other)
	{
		print (other.name);
		if(other.name=="FPSController")
			
		{
			GetComponent<Renderer>().material.color = Color.green;
			Debug.Log ("FPS Collided with CUBE");
		}
	}
