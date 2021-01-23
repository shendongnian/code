	Animation anim;
	void Awake()
	{
		anim = GetComponent<Animation>();
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
			anim.Play();
		else
			anim.Stop();
	}
