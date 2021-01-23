    if (UI_TB_UserInput.Text.Length > 0)
    {
    	byte[] asciiBytes = Encoding.ASCII.GetBytes(UI_TB_UserInput.Text);
    	byte minByte = asciiBytes[0];
    	byte maxByte = asciiBytes[0];
    	foreach (byte i in asciiBytes)
    	{
    		if (i < minByte)
    		{
    			minByte = i;
    		}
    		if (i > maxByte)
    		{
    			maxByte = i;
    		}
    
    	}
    	if (UI_RB_Min.Checked)
    	{
    		UI_LB_MinMaxOutput.Text = ((char)minByte).ToString();
    	}
    	else
    	{
    		UI_LB_MinMaxOutput.Text = ((char)maxByte).ToString();
    	}
    }
    else
    {
    	UI_LB_MinMaxOutput.Text = "";//If not > 0 then display blank
    }
