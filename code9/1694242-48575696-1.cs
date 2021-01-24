    public string Insert_Data(string NewCol1 , string NewCol2, string NewCol3, string NewCol4, double NewCol5)
    {
        string resultMessage;
        // your code here
        if (Count > 0)
        {
            resultMessage = "Record Already Exists.";
        }
        else
        {
           // code here
           resultMessage = "Inserted Sucessfully";
        }
        con.Close();
        return resultMessage;
        
    }
