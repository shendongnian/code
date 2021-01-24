	public static void Main (string[] args)
	{
		int value = 5;
		string str = Convert.ToString(value, 2);
		//string value 101
		char [] arr=str.ToCharArray (); // converts the string to array of char
	
		for (int i = 0; i < str.Length; i++)  // used to print the content of the array
			Console.WriteLine (arr [i]);
	}
