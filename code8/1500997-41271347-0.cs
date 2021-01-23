    DataSet ds = null;
    using (SqlConnection connection = new SqlConnection(sConnectionString))
    {
        connection.Open();
        SqlCommand Sqlcommand = new SqlCommand();
        Sqlcommand.CommandType = CommandType.StoredProcedure;
        if (SqlParamlist != null)
        {
            foreach (SqlParameter Sqlparameter in SqlParamlist)
            {
                Sqlcommand.Parameters.AddWithValue(Sqlparameter.ParameterName, Sqlparameter.Value);                                
            }
        }
        Sqlcommand.CommandText = sProc;
        Sqlcommand.Connection = connection;
        sProcParams = sProc + " " + sProcParams;
        using (SqlDataAdapter da = new SqlDataAdapter(Sqlcommand))
        {
            ds = new DataSet("DATATABLE");
            da.Fill(ds, "DATAROW");
            Sqlcommand.Parameters.Clear();
            da.Dispose();
        }
        connection.Close();
    }
    XmlDataDocument xDoc = new XmlDataDocument();
    xDoc.LoadXml(ds.GetXml());
