       public class Program {
    		public static void Main(string[] args) {
    			ChristmasCard card = new ChristmasCard();
    			ChristmasCardController controller = new ChristmasCardController();
    			controller.SomeMethod(card);
    			WriteToConsole(card);
    		}
    
    		public static void WriteToConsole(ChristmasCard card) {
    			Console.WriteLine(card.ToWhom);
    			Console.WriteLine(card.Message);
    			Console.WriteLine(card.FromWhom);
    			Console.ReadLine();
    		}
    	}
    
    
    	/// <summary>
    	/// Pure data class does not needs methods!
    	/// </summary>
    	public class ChristmasCard {
    		public string ToWhom { get; set; }
    		public string FromWhom { get; set; }
    		public double Decorate { get; set; }
    		public string Message { get; set; }
    	}
    
    	/// <summary>
    	/// Controller for the dataClass
    	/// </summary>
    	public class ChristmasCardController {
    		public void SomeMethod(ChristmasCard card) {
    			card.ToWhom = To();
    			card.FromWhom = From();
    			card.Decorate = ChooseDecoration();
    			card.Message = AddMessage();
    			DoPromt(card);
    			DisplayMessage(card.Decorate);
    		}
    
    		private void DisplayMessage(double cardDecorate) {
    			//Write your message to the console
    		}
    
    		private void DoPromt(ChristmasCard card) {
    			//Do some ConsoleRead in here
    		}
    		
    		private string AddMessage() {
    			throw new NotImplementedException();
    		}
    
    		private double ChooseDecoration() {
    			throw new NotImplementedException();
    		}
    
    		private string From() {
    			throw new NotImplementedException();
    		}
    
    		private string To() {
    			throw new NotImplementedException();
    		}
    	}
