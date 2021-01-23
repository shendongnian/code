    using(SqlCommand cmd = new SqlCommand())
    {
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "Select MOBILE_PHONE_NUMBER as Number From people Where FORENAME = @FORENAME and SURNAME = @SURNAME and PERSON_CODE = @PERSONCODE";
        cmd.Parameters.Add("@PERSONCODE", SqlDbType.NVarChar);
        cmd.Parameters.Add("@FORENAME", SqlDbType.NVarChar);
        cmd.Parameters.Add("@SURNAME", SqlDbType.NVarChar);
        foreach (string name in StringNames)
        {
            string[] StuName = name.Split('|');
            cmd.Parameters["@PERSONCODE"].Value = StuName[0]);
            cmd.Parameters["@FORENAME"].Value = StuName[1]);
            cmd.Parameters["@SURNAME"].Value = StuName[2]);
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    DataTable ndt = new DataTable();
                    sda.Fill(ndt);
                    dt.Merge(ndt);
                }
            }
        }
    } 
