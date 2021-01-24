    string both = "192.168.187.815,2332";
    string[] splitted = both.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
    string string1 = splitted[0];
	string string2 = splitted[1];
	
	
	Console.WriteLine(string1);
	Console.WriteLine(string2);
