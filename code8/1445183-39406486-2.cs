        string input = "18:40";
		DateTime time;
		
		var ok = DateTime.TryParse(input, out time);
		
		if (ok) {
            var timeString = string.Format("{0:00}{1:00}", time.Hour, time.Minute);
		}
		else {
			throw new ArgumentException($"Invalid input, expected time in format HH:MM. Actual input was '{input}'.", nameof(input));
		}
