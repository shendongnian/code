	var possibleChoices = new Dictionary<string,string>{
		{"1", "Latte"},
		{"2", "Cappuccino"},
		{"3", "Espresso"},
		{"4", "Double espresso"}
	};
	string value;
	var message = possibleChoices.TryGetValue(choice, out value)
		? string.Format("You have selected: {0}", value)
		: "Incorrect value, please try again";
    //In your code, the fall-through case misses the leading \n .
    //By avoiding repetition, consistency in formatting is achieved
    //with a single line of code
	Console.WriteLine("\n{0}", message); 
