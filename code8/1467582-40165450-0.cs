    // Class for Database input
    public class Course {
        public string Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
    // Class for JSON output
    public class StartEnd {
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
    }
	// Some data to test :)
	var testData = new[] {
		new Course() {
			Day = "Sunday",
			StartTime = DateTime.Parse("01-01-2000 08:20:00"),
			EndTime = DateTime.Parse("01-01-2000 10:20:00")
		},
		new Course() {
			Day = "Saturday",
			StartTime = DateTime.Parse("01-01-2000 11:00:00"),
			EndTime = DateTime.Parse("01-01-2000 14:00:00")
		},
		new Course() {
			Day = "Monday",
			StartTime = DateTime.Parse("01-01-2000 18:20:00"),
			EndTime = DateTime.Parse("01-01-2000 21:20:00")
		},
		new Course() {
			Day = "Saturday",
			StartTime = DateTime.Parse("01-01-2000 20:00:00"),
			EndTime = DateTime.Parse("01-01-2000 22:00:00")
		},
	};
	
	// The actual data processing
	var jsonData = testData
		.GroupBy(x => x.Day, x => new StartEnd() { Start = x.StartTime, Stop = x.EndTime })		// Convert to output type while grouping
		.ToDictionary(x => x.Key, x => x.ToArray());											// Convert to dictionary, iterating IEnumerables creates by GroupBy
