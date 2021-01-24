	//You can have an Enum for team types as
	public enum TeamType
	{
		 Barcelona, RealMadrid  // This can be extended at any point of time
	}
	//You can create a class as
	Class Team{
		//Properties
		public int ID{get; set;}
		public string Name{get; set;}
		public TeamType Type{get; set;}
		public int InputGames{get; set;}
		//Methods
		//write your methods here 
	}
	// You can write you program here to use these as
	class Program
	{
		 static void Main(string[] args)
		 {
			 //Program would be written here
			 //If one team is needed, you will create one object of Team class. 
			 //Similarily you can create as many number of Team object as many 
			 //teams you need
		 }
	}
