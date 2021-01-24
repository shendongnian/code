    public string updateselstatus(int sid, string[] trnasId, string[] resparr)
        {
            string ret = "";
            try
            {
                //con.Open();
                for (int j = 0; j < trnasId.Length; j++)
                {
                    con.Open();
                    string a = trnasId[j].Trim().ToString();
                    string b = resparr[j].Trim().ToString();
                    SqlCommand cmd = new SqlCommand("OIB_updateselstatus", con);
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sid", sid);
                    cmd.Parameters.AddWithValue("@smsid", trnasId[j].Trim().ToString());
                    cmd.Parameters.AddWithValue("@status", resparr[j].Trim().ToString());
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return ret;
            }
            catch (Exception ex)
            {
                con.Close();
                ret = ex.Message.ToString();
                return ret;
            }
            //finally { con.Close(); }
        }
