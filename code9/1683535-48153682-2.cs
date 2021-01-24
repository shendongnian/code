	public class SecondClass
	{
		public ThirdClass ThirdClass { get; }
		
		public SecondClass()
		{
			ThirdClass = new ThirdClass();
			ThirdClass.myEvent += this.OnCounted;
		}
		
		public void LaunchSecondClass()
		{
			if(ThirdClass == null)
				ThirdClass = new ThirdClass();
			
			ThirdClass.count();
		}
		private void OnCounted(object sender, EventArgs e)
		{
			Console.WriteLine("Second Class Here.");
			//Console.ReadLine();
		}
	}
	
