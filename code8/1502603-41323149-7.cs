    public bool CopyTransactionDataToTable(DataTable Dt, long ProductID)
        {
        
        try
        {
            SqlBulkCopy copy = new SqlBulkCopy(Adapter.GetActiveConnection().ConnectionString);
            Collection = mapping.LoadMappedNameEntityByProductID(ProductID);
            
            copy.ColumnMappings.Add("ProductID", "ProductID");
            copy.ColumnMappings.Add("ResellerID", "ResellerID");
            copy.ColumnMappings.Add("Status", "Status");
            copy.ColumnMappings.Add("PK_ID", "TxID");
            copy.DestinationTableName = "TBLProdect";
            copy.BulkCopyTimeout = ConfigurationSettings.AppSettings.Get(UIConstants.SQLTimeOut).ToInt32();
            copy.WriteToServer(Dt);
            Adapter.CommandTimeOut = copy.BulkCopyTimeout;
            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex);
            return false;
        }
    }
