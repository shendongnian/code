    public Rigidbody rb;
	public float forwardForce = 2f;
	public float bonusDuration = 2.0f;   
	private float endBonusTime = 0 ;
	private float cooldown = 5.0f;
	void FixedUpdate()
	{   
		if ( endBonusTime < Time.time + cooldown && Input.GetKeyDown("q") )
		{
			endBonusTime = Time.time + bonusDuration ;
		}
		else if ( endBonusTime < Time.time )
		{
			rb.AddForce(0, 0, forwardForce * Time.deltaTime);
		}
		if (endBonusTime >= Time.time ) // Don't put "else if"
		{
			rb.AddForce(0, 0, 1 * Time.deltaTime);
		}
	}
