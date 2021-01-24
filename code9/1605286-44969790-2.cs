    private byte[] StringToByteArray(string str)
    {
         System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
         return enc.GetBytes(str);
    }
    
