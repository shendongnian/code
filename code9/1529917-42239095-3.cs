    public void ColorInfo(string colorName)
    {
		try
		{
        	Colors color = (Colors)Enum.Parse(typeof(Colors), colorName);
	        switch (color)
	        {
	            case Colors.red:
	                Debug.Print("red color");
	                break;
	        }
		}
		catch(ArgumentException ex)
		{
            Debug.Print("Unknown color");
		}
    }
