    public static void Main()
	{
		//assigning values to variable
		double minutes = 2000;
		TimeSpan tspan = TimeSpan.FromMinutes(minutes); //converting minutes to timespan
		string res1 = (int)tspan.TotalHours +" Hours " + tspan.Minutes +" Minutes"; 
		
		string res2= (int)tspan.TotalHours + ":"+tspan.Minutes; 
		
		string res3= Convert.ToInt32(tspan.TotalHours)  + "."+tspan.Minutes +" Hours"; 
		
		Console.WriteLine(res1);
		Console.WriteLine(res2);
		Console.WriteLine(res3);
	}
