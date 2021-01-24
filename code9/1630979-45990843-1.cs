    {
        .../...
    
      	RenderTimer = new Timer();
    	UpdateTimer = new Timer();
    	RenderTimer.Tick += RenderTick;
    	UpdateTimer.Tick += UpdateTick;
    	var renderFrames = Convert.ToInt32(1000/frameRate);
    	var updateFrames = Convert.ToInt32(1000/updateRate);
    	RenderTimer.Interval = renderFrames;
    	UpdateTimer.Interval = updateFrames;
    	RenderTimer.Start();
    	UpdateTimer.Start();
    
        .../...
    }
