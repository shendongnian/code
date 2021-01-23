        string input = "18:40:59";
		DateTime time;
		
		var ok = DateTime.TryParse(input, out time);
		
		if (ok) {
			Console.WriteLine(time.TimeOfDay);
		}
		else {
			Console.WriteLine("Error");
		}
