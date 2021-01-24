	internal bool IsValidUser(string emailAddress)
	{
		var digestText = _sharedSecret + ":" + emailAddress;
		byte[] hashBytes;
		using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
		{
			hashBytes = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(digestText));
		}
		var digest = System.Convert.ToBase64String(hashBytes);
		string query = emailAddress + " d=" + digest;
		var sendBytes = Encoding.ASCII.GetBytes(query);
		
		_udpClient.Send(sendBytes, sendBytes.Length);
		IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
		var results = Encoding.ASCII.GetString(_udpClient.Receive(ref remoteIpEndPoint));
		//code which looks at results and return true/false here....
		return false;
	}
