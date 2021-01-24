    string sid, sname;
    sid = Request.QueryString["StudentId"].ToString();
    sname = Request.QueryString["StudentName"].ToString();
    string selectText = "SELECT studentID, StudentName FROM tblStudent WHERE 1=0";
    using(MySqlDataAdapter da = new MySqlDataAdapter(selectText, con))
    {
         MySqlCommandBuilder bd = new MySqlCommandBuilder(da);
         DataTable dt = new DataTable();
         da.Fill(dt);
         // This is important, because Update will work only on rows
         // present in the DataTable whose RowState is Added, Modified or Deleted
         dt.Rows.Add(sid, sname);
         da.Update(dt);
    }
