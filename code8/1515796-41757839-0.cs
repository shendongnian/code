    using (OdbcDataAdapter adapter = new OdbcDataAdapter(odbcCommand))
    {
        using (DataSetWithError ds = new DataSetWithError())
        {
            try
            {
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                ds.msg = ex;
            }
            finally
            {
                adapter.Close();
            }
        }
        return ds;
    }
