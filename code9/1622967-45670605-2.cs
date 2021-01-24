    bool[] checkstatus = { cb1.Checked, cb5.Checked, cb9.Checked, cb13.Checked };
    string[] checkid = { cb1.Text, cb5.Text, cb9.Text, cb13.Text };
    int j = checkid.Length; //this variable indicates the length of your array
    int f = checkstatus.Length; //this variable indicates the length of you array
    for (int i = 0; i < j; i++)
        {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SopProcess";
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CheckID", checkstatus[i]); //this should be the value
        cmd.Parameters.Add("@StatusClick", checkid[i]); // this should be the value
        cmd.ExecuteNonQuery();
        }
