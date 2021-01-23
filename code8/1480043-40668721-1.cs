    NpgsqlTransaction trans = conn.BeginTransaction(IsolationLevel.RepeatableRead);
    if (TruncateTable)
    {
        cmd = new NpgsqlCommand(string.Format("truncate table {0}", TableName), conn, trans);
        cmd.ExecuteNonQuery();
    }
    try
    {
        Stopwatch st = new Stopwatch();
        st.Start();
        string format = HasHeader ? "csv header" : "csv";
        cmd.CommandText = string.Format(
            "copy {0} from program 'gzip -dc /apps/external_data/inbound/{0}.csv.gz' " +
            "with null as '' {1} encoding 'WIN1250'", TableName, format);
        cmd.ExecuteNonQuery();
        trans.Commit();
        st.Stop();
        Results = string.Format("Upload Completed in {0}", st.Elapsed);
    }
    catch (Exception ex)
    {
        trans.Rollback();
        Results = ex.ToString();
        success = false;
    }
