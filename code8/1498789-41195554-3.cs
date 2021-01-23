    List<Control> controlsArray = new List<Control>();
    void FormLoad(...)
    {
    	for (var i = 0; i < 11; i++)
    		controlsArray.Add(null); //Dummy values
    	
    	controlsArray.Add(this.Controls.NW11);
    	controlsArray.Add(this.Controls.NW12);
    	controlsArray.Add(this.Controls.NW13);
    	controlsArray.Add(this.Controls.NW14);
    	controlsArray.Add(this.Controls.NW15);
    	controlsArray.Add(this.Controls.NW16);
    }
