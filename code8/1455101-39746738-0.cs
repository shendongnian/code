	int? protocol = 5;
	var age = false;
	var gender = false;
	var columnList = new List<string>();
	columnList.Add("Patient Id");
	
	if (protocol == null || protocol == 5)
	{
		columnList.Add("Patient Initial");
		columnList.Add("DOB");
		
		if (age)
		{
			columnList.Add("Age");
		}
		
		columnList.Add("Height");
		columnList.Add("Weight");
		columnList.Add("BMI");
		columnList.Add("Occupation");
		columnList.Add("Nationality");
		columnList.Add("Education");
		columnList.Add("Race");
		
		if (gender)
		{
			columnList.Add("Gender");
		}
		
		columnList.Add("MaritalStatus");
	}
	
	string columns = string.Join(",", columnList);
