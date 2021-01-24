	void Main()
	{
		Console.WriteLine (DecimalToTime(62.25)); // will output 62 Hours:15
	}
	
	string DecimalToTime(double dbTime)
	{
		int hour = (int)dbTime;
		int minute = (int)((dbTime - hour) * 60);
		
		string time = hour + " Hours:" + minute;
		
		return time;
	
	}
