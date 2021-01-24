     private string ByteArrayToString(byte[] arr)
        {
             System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
             return enc.GetString(arr);
        }
