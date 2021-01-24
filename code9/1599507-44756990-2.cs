    private static string ConvertHexToString(String hexInput, System.Text.Encoding encoding) {
        int numberChars = hexInput.Length;
        byte[] bytes = new byte[numberChars / 2];
        for (int i = 0; i < numberChars; i += 2) {
            bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
        }
        return encoding.GetString(bytes);
    }
    private static string ConvertStringToHex(String strInput, System.Text.Encoding encoding) {
        return BitConverter.ToString(encoding.GetBytes(strInput)).Replace("-", String.Empty);
    }
    private void button1_Click(object sender, EventArgs e) {
        string strTest = "对我很有帮助!";
        Debug.Print(strTest);
        string hex;
        hex = ConvertStringToHex(strTest, Encoding.UTF8);
        Debug.Print(hex);
        Debug.Print(ConvertHexToString(hex, Encoding.UTF8));
        hex = ConvertStringToHex(strTest, Encoding.Unicode);
        Debug.Print(hex);
        Debug.Print(ConvertHexToString(hex, Encoding.Unicode));
        Debug.Print(ConvertHexToString("F95B1162885F09672E5EA9522100", Encoding.Unicode));
    }
