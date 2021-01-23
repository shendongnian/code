    public DataSet getDataQuery(string txt)
    {
       try
       {
            String strQuery = @"Select Sale_Invoice_No, Item_Code, Item_Payable_Amount from sale where Sale_Invoice_No = '" + txt + "'";
                return SqlHelper.ExecuteDataset(your_connection_string_name, CommandType.Text, strQuery);
       }
    
      catch (Exception ex)
      {
         throw ex;
      }
