	public class MyInputClass
	{
		private string GetUserInput(string message)
		{
			Write(message);                
			return ReadLine();			
		}
		public double GetClerkNumber()
		{                
			return Convert.ToDouble(GetUserInput("Please Enter Clerk #: "));		
		}
		//put your other UI bits here; e.g. functions to get monthly sales, month number, etc
	}
	
