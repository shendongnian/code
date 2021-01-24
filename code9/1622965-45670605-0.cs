    bool[] checkstatus = { cb1.Checked, cb5.Checked, cb9.Checked, cb13.Checked };
    string[] checkid = { cb1.Text, cb5.Text, cb9.Text, cb13.Text };
    int j = checkid.Length;
    int f = checkstatus.Length;
    for (int i = 0; i < j; i++)
        {
        SqlCommand cmd = new SqlCommand("SopProcess", con);
        cmd.CommandText = "SopProcess";
    	cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CheckID", j);
        cmd.Parameters.Add("@StatusClick", f);
        cmd.ExecuteNonQuery();
        }
