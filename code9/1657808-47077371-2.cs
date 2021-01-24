    void Main()
    {
    	var file = @"at-2017@yahoo.com;
    we@yahoo.com
    at-2018@yahoo.com
    at-2017@yahoo.com
    at-2018@yahoo.com;";
    
    	using (var memory = new MemoryStream(Encoding.UTF8.GetBytes(file)))
    	using (var reader = new StreamReader(memory))
    	{
    		string line;
    		while ((line = reader.ReadLine()) != null)
    		{
    			var email = new StringBuilder(line)
    				.Replace(";", string.Empty)
    				.Replace(",", string.Empty)
    				.Replace(" ", string.Empty)
    				.ToString();
    			var isEmailValid = IsValidEmail(email);
    			Console.WriteLine($"{isEmailValid,-5}: {email,-20} original: {line}");
    		}
    	}
    }
    
    bool IsValidEmail(string strIn)
    {
        // Return true if strIn is in valid e-mail format.
        return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"); 
    }
