	public class ModelName
	{
		// other properties
		// original Birthday property
		public int Birthday {get;set;}
        // get age by subtracting current year with Birthday year.
		public int Aget {get {return DateTime.Now.Year - Birthday;}}
	}
