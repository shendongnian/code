    		public static void SendDatatoClient(string DataToSend)
		{
			//---write back the text to the client---
			byte[] bytesTosend = Encoding.GetEncoding("ISO-8859-1").GetBytes(DataToSend);
			byte[] Datalength = BitConverter.GetBytes((Int32)bytesTosend.Length);
			nwStream.Write(Datalength, 0, 4);
			nwStream.Write(bytesTosend, 0, bytesTosend.Length);
		}
