    public class SomeType
	{
		// Some properties.
	}
	public enum SomeTrigger
	{
		Loaded,
		Initial,
		Timer,
		Final
	}
	public abstract class SomeBaseObject
	{
		// 
		// I am not allowed to change this class. It is not mine.
		//
		protected Dictionary<string, SomeType> Input;
		protected Dictionary<string, SomeType> Output;
		// Timer is evaluated every 2 sec.
		public void Execute(SomeTrigger trigger, string value)
		{
			switch (trigger)
			{
				case SomeTrigger.Loaded:
					OnLoaded();
					break;
				case SomeTrigger.Initial:
					OnInitial();
					break;
				case SomeTrigger.Timer:
					OnTimer();
					break;
				case SomeTrigger.Final:
					OnFinal(value);
					break;
				default:
					break;
			}
		}
		protected abstract void OnLoaded();
		protected abstract void OnInitial();
		protected abstract void OnTimer();
		protected abstract void OnFinal(string value);
	}
	public class SomeSpecificObject : SomeBaseObject
	{
		private bool isInitializationCompleted;
		private string connection;
		
		protected override void OnLoaded()
		{
			// Read Input and Output collection.
		}
		protected override void OnInitial()
		{
			// Initialization (connect to the server).
			// Bla bla bla
			this.connection = "";//Value from the plug-in;
			isInitializationCompleted = true;
		}
		protected override void OnTimer()
		{
			if (isInitializationCompleted)
			{
				// Do something
				// Connection is using here.
				// Calculate values on a Input collection, etc.
			}
		}
		protected override void OnFinal(string value)
		{
			if (isInitializationCompleted)
			{
				// something with "value"
				// Connection is using here.
				// Clear state.
			}
			else
			{
				// Connection is using here.
				// Cancel inistialization
			}
		}
	}
