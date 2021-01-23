    var names = "Bob, George, Will, Terry";
	var lastCommaPosition = names.LastIndexOf(',');
	if (lastCommaPosition != -1) 
    {
		names = names.Remove(lastCommaPosition, 1)
				   //.Insert(lastComma, " and");
					 .Insert(lastCommaPosition, ", and");
	}
	
	Console.WriteLine(names);
