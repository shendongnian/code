	public static string ConvertHexToString(String hexInput, System.Text.Encoding encoding)
	{
	 	hexInput = hexInput.Replace(" ", "").Replace("-", "");      //Edited here to not declare a new string, suggested by Clonkex in comment
	    int numberChars = hexInput.Length;
	    byte[] bytes = new byte[numberChars / 2];
	    for (int i = 0; i < numberChars; i += 2)
	    {
	        bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
	    }
	    return encoding.GetString(bytes);
	}
