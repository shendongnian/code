    public static String EncryptURL(string strData)
    {
        try
        {
            if (!String.IsNullOrEmpty(strData))
            {
                using (SHA1Managed shaM = new SHA1Managed())
                {
                    // ASCIIEncoding.ASCII.GetBytes should return same byte array in this case
                    byte[] encbytedata = Encoding.ASCII.GetBytes(strData);
                    byte[] hash = shaM.ComputeHash(encbytedata);
    		        String encStrData = Convert.ToBase64String(hash);
    		        return encStrData;
                }
            }
    	    else
    	    {
    	        return "";
    	    }
        }
    	catch (Exception) { ... }
    }
