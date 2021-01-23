        var time = "24:25:30";
		var date = "1/1/2001";
		DateTime parsed = new DateTime();
		
		if(time.StartsWith("24")){
			time = "00" + time.Substring(2);
				
		}
		
		DateTime.TryParse(date + " " + time, out parsed);
			
			
		Console.WriteLine(parsed);
