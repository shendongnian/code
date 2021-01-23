    void Main()
    {
    	char[] charray = new char[7];
    
    	Console.WriteLine("Enter 7 unique alphabetic characters: ");
    
    	for (int i = 0; i < charray.Length; i++)
    	{
    		var x = Convert.ToChar(Console.ReadLine());
    		if (charray.Contains(x))
    		{
    			Console.WriteLine("Please enter a unique alphabetic character.");
    			i--;
    		}
    		else
    		{
    			charray[i] = x;
    		}
    	}
    	Console.WriteLine(charray);
    }
