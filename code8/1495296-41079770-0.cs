    //get the rest of the body
    string httpBody = string.Empty;
    byte[] bodyBuffer = new byte[10000];	//arbitrary buffer length
    string[] lines = message.Split('\n');	//split the header Message by newlines
    string StrLength = string.Empty;
    int contentLength = 0;
    foreach (string line in lines) {
    	if (line.Contains("content-length")) {
    		string[] splitLine = line.Split(':');
    		StrLength = splitLine[1];
    		break;
    	}
    }
    if (StrLength != null) {
    	try {
    		contentLength = int.Parse(StrLength);
    	}
    	catch {
    		Console.WriteLine("Failed to parse content-length");
    	}
    }
    else {
    	Console.WriteLine("content-length header not found");
    }
    int bodyReadResult = sock.Receive(bodyBuffer);
    if (bodyReadResult != contentLength) {
    	Console.WriteLine("Failed to read all of HTTP body, probably sent as a multipart");
    }
    httpBody = Encoding.ASCII.GetString(bodyBuffer, 0, bodyReadResult);
