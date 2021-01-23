    DataSet dsFirst = new DataSet();
            var initialCount = dsFirst.Tables[0].Rows.Count;
    
            DataSet dsRefreshed = new DataSet();
    
            for (int i = 0; i < initialCount; i++)
            {
                dsRefreshed.Tables[0].Rows.RemoveAt(i);
            }
    
            dg.DataSource = dsRefreshed;
   
    
