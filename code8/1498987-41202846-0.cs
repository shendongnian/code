    using (conn = new SqlConnection(SQLConn))
    using (cmd = new SqlCommand(storedprocname, conn))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Name", cboNames.Text);
        cmd.Parameters.AddWithValue("d1", dtpd1.Value.ToShortDateString();
        cmd.Parameters.AddWithValue("d2", dtpd2.Value.ToShortDateString();
        cmd.Parameters.AddWithValue("@Dolla", cboDolla.Text);
        using (da = new SqlDataAdapter(cmd))
        {
            da.Fill(dt);
        }
        var numberOfRecords = dt.Rows.Count;
        MessageBox.Show(numberOfRecords);
    }
