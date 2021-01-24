    Remove the unwanted code..Try Like this..
    
   
     List<tmp_WatchList> data = new List<tmp_WatchList>();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd=new SqlCommand();
        cmd.CommmandText="sp_CheckPersonList";
        cmd.CommandType = CommandType.Text;
        con.Open();
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@Name",name);
        SqlDataReader oReader = cmd.ExecuteReader();
        
                while (oReader.Read())
                {
                    tmp_WatchList l = new tmp_WatchList();
                    l.id = int.Parse(oReader["id"].ToString());
                    l.Name = oReader.GetValue(1).ToString();
                    l.Crime = int.Parse(oReader.GetValue(2).ToString());
                    data.Add(l);
                }
        
        oReader.Close();
        Con.Close();
