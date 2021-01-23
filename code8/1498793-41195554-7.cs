    private void RefreshTimer_Tick(object sender, EventArgs e)
    {
    	for (int Count = 11; Count <= 16; Count++)
    	{
            if (controlsArray[Count] == null)
                continue; //To be on the safe side
    		Properties.Settings.Default._NW[Count] = controlsArray[Count].Value;
    	}
   		Properties.Settings.Default.Save(); //Do this after the assignment loop has finished
    }
