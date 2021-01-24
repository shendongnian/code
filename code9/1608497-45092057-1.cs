	string inputData = "123.456";
	//string inputData = "Some invalid data";
	
	double result;
	var success = Double.TryParse(inputData, out result);
	if (success) {
		// Use result as desired
	} else {
		// Failed to parse input string
	}
