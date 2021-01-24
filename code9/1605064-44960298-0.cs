    public string SwitchDate(string date)
	{
		Debug.Log ("Date IN: Switch " + date);
		string[] inputSections=date.Split('/');
		string ServiceDate=string.Format("{0}/{1}/{2}", inputSections[2], inputSections[0], inputSections[1]); 
		Debug.Log ("Date OUT: Switch " + ServiceDate);
		return ServiceDate;
	}
 
	string SwitchbackDate(string date)
	{
		Debug.Log ("Switchback In: " +date);
		string[] inputSections=date.Split('/');
		string ServiceDate=string.Format("{0}/{1}/{2}",inputSections[1], inputSections[2], inputSections[0]); 
		Debug.Log ("Switchback Out: " + ServiceDate);
		return ServiceDate;
	}
