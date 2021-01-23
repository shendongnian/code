    foreach (var substring in output)
    {               
    	int value;
    	if(int.TryParse(substring, out value)){
            value = value * 2;
    		input = input.Replace(substring, value.ToString());
    	}
    }
    Console.WriteLine(input);
