    public static void Main(string[] args)
        {
            string myName = "Angel Hadzhiev";
        	char[] CharName = myName.ToCharArray();
        	Array.Reverse(CharName);
        	foreach (char name in CharName)
        	{
            	Console.WriteLine(name);
        	}
        }
