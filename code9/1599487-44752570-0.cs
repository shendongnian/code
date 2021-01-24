    public static string ConvertStringToHex(String input, System.Text.Encoding encoding)
    {
        string hex = "";
        byte[] data = encoding.GetBytes(input);
        for (int i = 0; i < data.Length; i++)
        {
            hex += Convert.ToString(data[i], 16);
        }
        return hex;
    }
    
    public static string ConvertHexToString(String hexInput, System.Text.Encoding encoding)
    {
        int numberChars = hexInput.Length;
        byte[] bytes = new byte[numberChars / 2];
        for (int i = 0; i < numberChars; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
        }
        return encoding.GetString(bytes);
    }
    
    string temp = ConvertStringToHex("張柏榆", System.Text.Encoding.UTF8);
    string temp1 = ConvertHexToString(temp, System.Text.Encoding.UTF8);
