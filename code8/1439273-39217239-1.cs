    class MainClass
	{
		public int mode = 31416;
		ObjectA obj = new ObjectA();
		
		
		public MainClass() 
		{
			obj.ValueReturnEvent += HandleValueReturnEvent;
		}
	
		public int GetMainClassMode() 
		{
			return mode;
		}
		
		// Handle event, return data
		private int HandleValueReturnEvent(object sender, EventArgs e)
		{
			return mode;
		}
		
		public void Test() {
			Console.WriteLine("Calling test method inside obj");
			obj.Test();
		}
	}
	
	class ObjectA {
		
		// delegate
		public delegate int ReturnValueEventHandler(object sender, EventArgs args);
		// event
		public event ReturnValueEventHandler ValueReturnEvent;
			
		
		public void Test() 
		{
			// make sure at least one subscriber
			if (ValueReturnEvent != null)  
			{
				// note the event is returning a value
				var myValue = ValueReturnEvent(this, null);
				
				Console.WriteLine("Getting mode from 'parent' MainClass");
				Console.WriteLine(string.Format("Mode = {0}", myValue));
			}
		}	
	}
