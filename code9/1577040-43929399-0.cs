    public void populatetransaction()
        {
            TRANASACTIONHISTRORYDataContext th = new TRANASACTIONHISTRORYDataContext();
            DataTable dt = new DataTable();
            var query= th.TRANSACTIONSP((System.Nullable<long>)Convert.ToInt32(hidreference.Value));
            DataColumn dc1 = dt.Columns.Add("BTC", typeof(string));
            dc1.AllowDBNull = true;
            DataColumn dc2 = dt.Columns.Add("TRANSACTIONDATE", typeof(DateTime));
            dc2.AllowDBNull = true;
            DataColumn dc3 = dt.Columns.Add("TRANSACTIONSTATUS", typeof(string));
            DataRow dw ;
            dc3.AllowDBNull = true;
          
            foreach (var c in query)
            {
                dw=dt.NewRow();
                dw["BTC"] = c.BTC;
                dw["TRANSACTIONDATE"] = c.TRANSACTIONDATE;
                dw["TRANSACTIONSTATUS"] = c.TRANSACTIONSTATUS;
                dt.Rows.Add(dw);
            }
           }
