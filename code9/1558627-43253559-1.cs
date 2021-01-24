	 public static void Main()
	 {
		Console.WriteLine("Welcome");
        // ask for the name and assign the return value to the local variable `myName`	
		string myName = AskName();
	 
		Console.WriteLine("Hey {0},welcome to the quiz! ", myName);
		
        // enter the first question, pass the variable `myName` as parameter.
		FstQuestion(myName);
	 }
	 
	 public static string AskName()  // <- notice the return type `string` instead of `void`
	 {
		Console.Write("What's your name ? : ");
		string myName = Console.ReadLine();
        // this will return the value of `myName` to the caller.
		return myName;
	 }
	 //Quiz introduction
	public static void FstQuestion(string myName)  // <-- notice the parameter
	{
		 //code
		if(...)
		 {
		 Console.WriteLine(" That's correct,{0} ! ",myName);
		 }
		 else
			Console.WriteLine(" Keep trying,{0} ",myName);
	}
