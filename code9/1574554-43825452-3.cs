    using (var db = new OleDbConnection(ConnectionString))
    {
        var query = Constants.UpdateSample;
        DynamicParameters pars = new DynamicParameters();
        pars.Add("@Clerk", sample.Clerk, DbType.String);
        // ... and so on for all parameters following the order of the placeholders
        // but end with ....
        pars.Add("@GRV", sample.GRV, DbType.String);
        pars.Add("@PalletSeq", sample.PalletSeq, DbType.String);
        pars.Add("@SampleNo", sample.SampleNo, DbType.String);
        return db.Execute(query, pars);
    }
