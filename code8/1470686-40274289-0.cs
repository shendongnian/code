    string controlName = "TextBlock";
    int startIndex = 1;
    int endIndex = 100;
	List<string>  stringList = new List<string>();
	for(int i = 0; i < 100 ; i++)
		stringList.Add("string"+(i+1).ToString());
	
	for(int i = startIndex; i<=endIndex; i++)
	{
		foreach(control c in TextBlock1.Parent.Controls)//Or if you know the actual parent to which all the textBoxes belong
		{
			if(c.Name == (controlName+i))
			{				
				(c as TextBlock).Text = stringsList[i-1]; //since our start index starts with 1. 
				break;					 
			}
		}
	}
