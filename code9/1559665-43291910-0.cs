    public static int convertint(string value)
    {
        int pass = 0;
        try
        {
             if (value != "")
             {  
          /* --> */  pass = Convert.ToInt32(value);
             }
        }
        catch
        {
        }
        return pass;                     
    }
