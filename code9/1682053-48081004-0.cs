    using(SqlConnection con = new SqlConnection(connectionString))
    {
        con.Open();
        using(SqlTransaction trans = con.BeginTransaction())
        using(SqlCommand cmd = new SqlCommand(strCommand, con, trans))
        using(SqlDataAdapter da = new SqlDataAdapter(cmd))
        {
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            cmb.GetInsertCommand().Transaction = trans;
            cmb.GetUpdateCommand().Transaction = trans;
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(sourceDt);
            sourceDt.Merge(clonedDt, false, MissingSchemaAction.AddWithKey);
            int count = da.Update(sourceDt);
            trans.Commit();
        }
    }
