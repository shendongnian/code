    private void Eval_String(string s)
    {
    	double tempVal;
    	string[] eachparam = s.Split(',');
    	
    	//Check the length of the response to ensure its the whole thing
    	if (eachparam.Length == 4))
    	{
    		//Loop through each string and parse it to a double
    		for (int i = 0; i < 4; i++)
    		{
    			if (double.TryParse(eachparam[i], out tempVal))
    			{
    				data[i] = tempVal;
    			}
    		}
    	}
    	else
    	{
    		//log error?
    	}
    }
