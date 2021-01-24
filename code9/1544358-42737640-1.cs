	public class AdditionalWorkerDelegate : IWorkerDelegate
	{
		public void PreformAdditionalWork()
		{
			Console.WriteLine("IWorkerDelegate.PreformAdditionalWork");
		}
	}
