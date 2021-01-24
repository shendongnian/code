	using System.Threading;
	namespace ConsoleApp1
	{
		class LightBuffer
		{
			public LightBuffer(int size)
			{
				Data = new byte[size];
			}
			public byte[] Data{ get; }
			public int Length{ get; set; }
			public ManualResetEvent DataReady{ get; } = new ManualResetEvent(false);
			public ManualResetEvent WriteDone{ get; } = new ManualResetEvent(true);
			public bool IsFinal{ get; set; }
			public int Number{ get; set; }
		}
	}
