    public class Program {
		public static void Main() {
			ChristmasCard card = new ChristmasCard();
			card.SomeMethod();
			ChristmasCardTesting testing = new ChristmasCardTesting();
			testing.SantaA(card);
		}
	}
	public class ChristmasCard {
		public string ToWhom { get; set; }
		public string FromWhom { get; set; }
		public double Decorate { get; set; }
		public string Message { get; set; }
		public void SomeMethod() {
			this.ToWhom = To();
			this.FromWhom = From();
			this.Decorate = ChooseDecoration();
			this.Message = AddMessage();
			DoPromt(message);
			DisplayMessage(decorate);
			Console.ReadLine();
		}
	}
	public class ChristmasCardTesting  {
			
			public void SantaA(ChristmasCard card) {
				Console.WriteLine(card.ToWhom);
				Console.WriteLine(card.Message);
				Console.WriteLine(card.FromWhom);
				Console.ReadLine();
			}
	}
