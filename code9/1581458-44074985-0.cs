    SqlTransaction transaction;
    try
    {
        using(SqlConnection con = new SqlConnection(.....))
        using(SqlCommand cmd = new SqlCommand("Single_Col_Update", con))
        {
            con.Open();
            transaction = con.BeginTransaction())
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Record_ID", SqlDbType.Int);
            cmd.Parameters.Add("@UpdColumn", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@UpdValue", SqlDbType.NVarChar, 255);
            foreach (string record in recordnumber)
            {
                cmd.Parameters["@Record_ID"].Value = Convert.ToInt32(record));
                cmd.Parameters["@UpdColumn"].Value = Session["UpdColumn"].ToString();
                cmd.Parameters["@UpdValue"].Value = Session["UpdValue"].ToString();
                cmd.ExecuteNonQuery();
            }
            transaction.Commit();
        }
    }
    catch(Exception ex)
    {
         // show a message to your users
         transaction.Rollback();
    }
