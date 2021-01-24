		public void FlushReceiveBuffer()
		{
			byte[] info	= new byte[2];
			byte[] outval = new byte[2000];
			try
			{
				mySock.IOControl(IOControlCode.DataToRead, info, outval);
				uint bytesAvailable = BitConverter.ToUInt32(outval, 0);
				if (bytesAvailable != 0 && bytesAvailable < 2000)
				{
					int len = mySock.Receive(outval); //Flush buffer
				}
			}
			catch
			{
				//Ignore errors
				return;
			}
		}
