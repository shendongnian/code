	public class Student
	{
		[JsonProperty("grades"), 
		JsonConverter(typeof(IntConverter))]
		public int Grades;
	}
