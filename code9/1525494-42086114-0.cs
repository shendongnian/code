    bool triggerMainPressed;
    bool triggerSecondaryPressed;
    
    void Update()
    {
    	if (controllerMain.GetPressDown(triggerButton))
    	{
    		triggerMainPressed = true;
    	}
    	if(controllerSecondary.GetPressDown(triggerButton))
    	{
    		triggerSecondaryPressed = true;
    	}
    	
    	if (controllerMain.GetPressUp(triggerButton))
    	{
    		triggerMainPressed = false;
    	}
    	if(controllerSecondary.GetPressUp(triggerButton))
    	{
    		triggerSecondaryPressed = false;
    	}
    	
    	
    	if(triggerMainPressed && triggerSecondaryPressed)
    	{
    		scaleSelected(gameObj); //enlarges selected GameObject based on distance between controllers
    	}
    	else if(triggerMainPressed && controllerSecondary.GetPressDown(gripButton))
    	{
    		deleteObject(gameObj); //delete selected GameObject
    	}	
    }
