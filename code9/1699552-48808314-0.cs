	using System;
	namespace DisposableConnection
	{
		class Program
		{
			static void Main(string[] args)
			{
				var device = new Device();
				using (device.Open())
				{
					device.Write();
				}
				Console.ReadKey();
			}
		}
		public class Device : IDisposable
		{
			public Device()
			{
			}
			public IDisposable Open()
			{
				Console.WriteLine("Open!!");
				return this;
			}
			public void Close()
			{
				Console.WriteLine("Close!!");
			}
			internal void Write()
			{
				Console.WriteLine("Write!!");
				//throw new Exception();   // optional, also works
			}
			public void Dispose()
			{
				Close();
			}
		}
	}
