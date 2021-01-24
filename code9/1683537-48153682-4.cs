	public class SecondClass
	{
		public void LaunchSecondClass(Action action)
		{
			ThirdClass third = new ThirdClass();
			third.myEvent += this.OnCounted;
			
			if(action != null)
				third.myEvent += (o, a) => action.Invoke();
			
			third.count();
		}
		private void OnCounted(object sender, EventArgs e)
		{
			Console.WriteLine("Second Class Here.");
			//Console.ReadLine();
		}
	}
	
