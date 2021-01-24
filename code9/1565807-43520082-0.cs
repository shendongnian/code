    private void Arduino_Write(string Output)
    {
    	if (networkStream != null) {
    		var sendBytes = Encoding.ASCII.GetBytes(Output);
    		var endByte = { 0xfe };
    		networkStream.Write(sendBytes, 0, sendBytes.Length);
    		networkStream.Write(endByte, 0, 1);
    	} else {
    		Interaction.MsgBox("ERROR");
    	}
    }
