     adapter.FillError += new FillErrorEventHandler(FillError);
     DataSet dataSet = new DataSet();
     adapter.Fill(dataSet, "ThisTable");
     protected static void FillError(object sender, FillErrorEventArgs args)
     {
         if (args.Errors.GetType() == typeof(System.OverflowException))
               {
                   // Code to handle precision loss.
                   //Add a row to table using the values from the first two            
                   columns.
                   DataRow myRow = args.DataTable.Rows.Add(new object[]
                   {args.Values[0], args.Values[1], DBNull.Value});
                   //Set the RowError containing the value for the third column.
                    args.RowError = 
                   "OverflowException Encountered. Value from data source: " +
                    args.Values[2];
                    args.Continue = true;
                }
      }
