	protected override void Movement()
		{
		float mm = mpsNow * typeSpeedFactor;
		
		if ( fallingMotion )
			transform.Translate(
				-Time.deltaTime * mm,
					-Time.deltaTime * mm * fallingness, 0f,
				Space.Self );
		else
			transform.Translate(
				-Time.deltaTime * mm, 0f, 0f,
				Space.Self );
		}
