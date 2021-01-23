	//loop for each user
	for (iCount = 1; iCount <= iUserNumber; iCount++)
	{
		Console.Write("Please Enter your Name" + iCount + ": ");
		var sName = Console.ReadLine(); // remove the previous instance you had of sName and make it a scoped variable to the for loop
		using (StreamWriter sw = new StreamWriter("NewUser" +sName + ".txt", true))
		{ /*use the streamwriter here */ }
    }
