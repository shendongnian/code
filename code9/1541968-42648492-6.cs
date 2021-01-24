	public class PacketReader
	{
		private byte[] _receiveBuffer = new byte[2];
		
		public void StartReceiving(Socket socket, Action<ArraySegment<byte>> process)
		{
			SocketReader.ReadFromSocket(socket, 2, _receiveBuffer, (headerData) =>
			{
				if(headerData.Count == 0)
				{
					// nothing/closed
					return;
				}
				// Read the length of the data.
				int length = BitConverter.ToInt16(headerData.Array, headerData.Offset);
				// if the receive buffer is too small, reallocate it.
				if(_receiveBuffer.Length < length)
					_receiveBuffer = new byte[length];
				SocketReader.ReadFromSocket(socket, length, _receiveBuffer, (dataBufferSegment) =>
				{
					if(dataBufferSegment.Count == 0)
					{
						// nothing/closed
						return;
					}
					try
					{
						process(dataBufferSegment);
					}
					catch { }
					
					StartReceiving(socket, process);
				});
			});	
		}
	}
	
	
