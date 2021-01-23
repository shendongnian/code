    Quaternion qStart, qEnd;
    float angle = 20.0f;
    float previousLerpFactor;
    
    public float speed;
    public AudioSource Sound;
    void Start () {
		qStart = Quaternion.AngleAxis ( angle, Vector3.forward);
		qEnd   = Quaternion.AngleAxis (-angle, Vector3.forward);
	}
    void Update () {
            //Lerp factor
            float lerpFactor = (Mathf.Sin(Time.time * speed) + 1.0f) / 2.0f;
    
            //rotation code
    		transform.rotation = Quaternion.Lerp (qStart, qEnd, lerpFactor);
    		
            //Playing Sound
    		if (((lerpFactor >= 0.5f) ^ (previousLerpFactor >= 0.5f)) && Time.timeScale!=0)
    			Sound.Play ();
            previousLerpFactor = lerpFactor;
    	}
