    while((SingleNumb = sr.ReadLine()) != null)
    {
    	float value = 0.0f;
    	if(float.TryParse(s, out value))
    	{
    		MessageBox.Show(value.ToString());
    	}
    	else
    	{
    		MessageBox.Show("Conversion failed!");
    	}
    }
