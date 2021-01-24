       public string updateselstatus(int sid, string[] trnasId, string[] resparr)
        {
            string ret = "";
            try
            {
                for (int j = 0; j < trnasId.Length; j++)
                {
                    //string a = trnasId[j].Trim().ToString();
                    //string b = resparr[j].Trim().ToString();
                    SqlCommand cmd = new SqlCommand("OIB_updateselstatus", con);
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sid", sid);
                    cmd.Parameters.AddWithValue("@smsid", trnasId[j].Trim().ToString());
                    cmd.Parameters.AddWithValue("@status", resparr[j].Trim().ToString());
                    // New Code 
                    adp.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    try
                    {
                        adp.Fill(dt);
                        
                    }
                    catch (Exception exp)
                    {
                        ret = exp.Message.ToString();
                        return ret;
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                ret = ex.Message.ToString();
                return ret;
            }
        }
