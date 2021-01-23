		public async Task<bool> SendandReceiveAsync(string portnum, byte cmd, string file)
		{
		
			bool task_state = await Task.Factory.StartNew(()=>ReadWriteSerialData(portnum, cmd, file));
		
			if (task_state)
				return true;
			else
				return false;
		}
