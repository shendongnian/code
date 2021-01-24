    private void Arduino_Write(string Output)
    {
    	if ((networkStream != null)) {
    		Byte[] sendBytes = Encoding.ASCII.GetBytes(Output);
    		Byte[] endByte = { 0xfe };
    		networkStream.Write(sendBytes, 0, sendBytes.Length);
    		networkStream.Write(endByte, 0, 1);
    	} else {
    		Interaction.MsgBox("ERROR");
    	}
    }
