    public string tostrFor(int n)
    {
    	string s = "";
    	for (int index = 0; index < string.Concat(n--, "").Length; index++)
    	{
    		char c = string.Concat(n--, "")[index];
    		s = s + c;
    	}
    	return s;
    }
