	public class ProcessRunner
	{
		/// <summary>
		/// Gets or sets the running process.
		/// </summary>
		private Process RunningProcess { get; set; }    
		
		/// <summary>
		/// The exepath of the process.
		/// </summary>
		private readonly string exePath;
		
		public ProcessRunner(string exePath)
		{
			this.exePath = exePath;
		}
		/// <summary>
		/// Runs the specified executable path.
		/// </summary>
		/// <param name="exePath">The executable path.</param>
		public void Run()
		{
			var processInfo = new ProcessStartInfo { Arguments = "<Your Args>", FileName = exePath, WindowStyle = ProcessWindowStyle.Normal };
			try
			{
				this.RunningProcess = Process.Start(processInfo);
			}
			catch (Exception exception)
			{
				throw new ProcessRunnerException(exception.Message);
			}
		}
		/// <summary>
		/// Terminates this instance.
		/// </summary>
		public void Terminate()
		{
			if (this.RunningProcess != null)
			{               
				this.RunningProcess.Kill();
				this.RunningProcess.Dispose();
			}
		}
	}
	public class ProcessManager
	{
		private readonly IList<ProcessRunner> MyProcessors{ get; }
		
		public ProcessManager()
		{
			MyProcessors = new List<ProcessRunner>();
			MyProcessors.Add(new ProcessRunner("myexe.exe")); // Add as many as you want.
		}
		
		public void RunAll()
		{
			foreach(var proc in MyProcessors)
			{
				proc.Run();
			}
		}
		
		public void KillAll()
		{
			foreach(var proc in MyProcessors)
			{
				proc.Terminate();
			}
		}	
	}
