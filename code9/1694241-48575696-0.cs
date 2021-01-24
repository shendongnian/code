    public string Insert_Data(string NewCol1 , string NewCol2, string NewCol3, string NewCol4, double NewCol5)
    {
       try
       {
            // your code here
            if (Count > 0)
            {
                return "Record Already Exists.";
            }
            else
            {
              // code here
                return "Inserted Sucessfully";
            }
           
       }
       catch
       {
            return "Error occured";
       }
       finally
       {
            con.Close();
       }
    }
