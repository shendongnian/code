	listInput[0] = "Apple";
	listInput[1] = "Banana";
	listInput[2] = "Orange";
	string Prefix = "My-";         
    string strOutput = string.Join(",", listInput.Select(x=> Prefix + x));
    Console.WriteLine(strOutput);
