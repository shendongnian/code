    string input = "tung2003";
		
    string output = string.Empty;
		
    foreach(char c in input)
    {
        if(char.IsNumber(c))
		{
		    output += c;
		}
		else
		{
		    output += ((byte)c).ToString();
		}			
    }
    //output is now: 1161171101032003
