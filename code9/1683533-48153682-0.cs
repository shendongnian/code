	public class SecondClass
	{
		public event EventHandler SecondEvent;
		
		public void LaunchSecondClass()
		{
			ThirdClass third = new ThirdClass();
			third.myEvent += this.OnCounted;
			third.count();
		}
		private void OnCounted(object sender, EventArgs e)
		{
			Console.WriteLine("Second Class Here.");
			//Console.ReadLine();
			SecondEvent?.Invoke(); // Based on C# 6
		}
	}
	
