	var dictionary = new Dictionary<string, System.Drawing.Color>();
		dictionary.Add("red color", System.Drawing.Color.Red);
		dictionary.Add("Blue color", System.Drawing.Color.Blue);
	//as above example you can use for loop and get each line of rich textbox
	string linefromTextBox = "Blue color";
	//then check that line contain of of text in the dictionaly 
	if (dictionary.ContainsKey(linefromTextBox))
	{
	   // if key found then you can get the color as below
	   // asign this as SelectionColor 
	   //before that you need to Select the line from rich text box as above example
	   var color = dictionary[linefromTextBox];
	} 
