	void OnMouseUpAsButton()
	{
		if(!clicked)
		{
			clicked = true;
			return;
		}
		if(Time.time <= (clickTime + clickDelta))
		{
			//Double Click occured
			clicked = false;
		}
	}
	void Update()
	{
		if(clicked)
		{
		   if(Time.time >= (clickTime + clickDelta))
		   {
			   //Handle single click
			   clicked = false;
		   }
		}
	}
