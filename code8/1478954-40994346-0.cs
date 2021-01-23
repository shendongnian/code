	public class SomeActor : ReceiveActor
	{
		public SomeActor()
		{
			// create child actors
			Become(Ready);
		}
		private void Ready()
		{
			Receive<InitMessage>(m =>
			{
				Become(Working1);
			});
			
			Receive<Terminated>(HandleTermination);
		}
		private void Working1()
		{
			Receive<InitMessage>(m =>
			{
				Become(Working2);
			});
			Receive<Terminated>(HandleTermination);
		}
		private void Working2()
		{
			Receive<InitParcerMessage>(m =>
			{
				Become(Working1);
			});
			Receive<Terminated>(HandleTermination);
		}
		private void Terminated()
		{
			// do some stuff
		}
		
		// Here's our method to perform the same job with our Terminated parameter
		private void HandleTermination(Terminated termination)
		{
            // Call our Become method
			Become(Terminated);
		}
	}
