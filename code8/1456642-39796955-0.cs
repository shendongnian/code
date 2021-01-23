	if (byteLoc < 4)
	{
		preamble += Convert.ToString(singleByte);
		preamble += " ";                        
	}
	//Message Type - 1 byte
	else if (byteLoc == 4)
	{
		msgType += Convert.ToString(singleByte);
	}
	//Message Length - 3 bytes
	else if (byteLoc <= 7)
	{
		msgLen += Convert.ToString(singleByte);
		Console.WriteLine("Len:" + byteLoc);  //for debug
	}
	//Test ID - 4 bytes
	else if (byteLoc <= 11)
	{
		testID += Convert.ToString(singleByte);
		Console.WriteLine("ID:" + byteLoc);   //for debug
	}
