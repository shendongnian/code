    var parameters = new string[alreadyAnsweredQues.Count];
    var cmd = new SqlCommand();
    for (int i = 0; i < alreadyAnsweredQues.Count; i++)
    {
        parameters[i] = string.Format("@qid{0}", i);
       
        
        cmd.Parameters.Add(parameters[i].ToString(), SqlDbType.Int,System.Int32.MaxValue).Value = alreadyAnsweredQues[i];
    }
    
    cmd.Parameters.Add("@cid", SqlDbType.Int, System.Int32.MaxValue).Value = Convert.ToInt32(Session["c_id"].ToString());
    
    cmd.CommandText = string.Format("SELECT TOP 1 * FROM questions WHERE c_id = @cid AND q_id NOT IN ({0}) ORDER BY NEWID() ;", string.Join(", ", parameters));
    System.Diagnostics.Debug.WriteLine(string.Format("SELECT TOP 1 * FROM questions WHERE c_id = @cid AND q_id NOT IN ({0}) ORDER BY NEWID() ;", string.Join(", ", parameters)));
    cmd.Connection = new SqlConnection(ConnectionClass.constr);
    cmd.Connection.Open();
    cmd.Prepare();
