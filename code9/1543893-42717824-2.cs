    public Boolean AddWorkProgress(int WorkID, int ContractorID, float PhysicalProgress, decimal FinancialProgress, int UserID, int OrgID, float FinancialProgressPecentage)
    {
        using(var connection=DataBaseConnection.OpenConnection())
        using(var transaction= connection.BeginTransaction()) 
        {
            _addProgressCmd.Parameters["@Work_ID"].Value=WorkID;
            ....
            _addProgressCmd.Connection=connection;
            _addProgressCmd.Transaction=transaction;
            _addProgressCmd.ExecuteNonQuery();
            transaction.Commit();
            
            var status=(bool)_addProgressCmd.Parameters["@ReturnStatus"].Value;
            var statusMsg=(string)_addProgressCmd.Parameters["@ReturnStatusMessage"].Value;
            //Process the results
            ...
        }
    }
