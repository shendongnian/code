	public class Form1: Form1
	{
		private int timeoutInMsec = 10000;
		private System.Windows.Forms.Timer _timer;
		private Thread _connectThread;
		
		public Form1()
		{
			_connectThread = new Thread(Connect);
			_connectThread.Start();
			
			_timer = new System.Windows.Forms.Timer() { Interval = timeoutInMsec };
			_timer.Tick += (_s, _e) => 
					{
						_timer.Stop();
						if (_connectThread.ThreadState == ThreadState.Running)
							_connectThread.Abort();
					};
			};
		}
		private void Connected()
		{
		
		}
		
		private void Aborted()
		{
		
		}
		
		private void Connect()
		{
			try
			{
				DoConnect3rdPartyStuff();
				this.Invoke(Connected);
			}
			catch(ThreadAbortException)
			{
				// aborted
				this.Invoke(Aborted);
			}		
		}	
	}
