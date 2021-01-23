     public static string base64Encode(string sData) // Encode
     {
       try
        {
           byte[] encData_byte = new byte[sData.Length];
           encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
           string encodedData = Convert.ToBase64String(encData_byte);
           return encodedData;
        }
       catch (Exception ex)
       {
           throw new Exception("Error in base64Encode" + ex.Message);
       }
     }
    public static string base64Decode(string sData) //Decode
     {
        try
        {
          var encoder = new System.Text.UTF8Encoding();
          System.Text.Decoder utf8Decode = encoder.GetDecoder();
          byte[] todecodeByte = Convert.FromBase64String(sData);
          int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
          [] decodedChar = new char[charCount];
          utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
          string result = new String(decodedChar);
          return result;
       }
      catch (Exception ex)
       {
          throw new Exception("Error in base64Decode" + ex.Message);
        }
    }
