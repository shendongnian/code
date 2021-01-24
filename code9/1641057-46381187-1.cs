    public void checktablenoandchangebtncolor()   
    {
      var btns = this.GetAllControls()
        .OfType<Button>()
        .ToLookup(x=>x.Text, x=>x);
      var list = new List<string>();
      var query = "SELECT tableno FROM kottemp";
      using(var con=new SqlConnection( ... ))
      {
        con.Open();
        using(var cmd=new SqlCommand(query,con))
        using(var dr=cmd.ExecuteReader())
        {
          while(dr.Read())
          {
            list.Add(dr["tableno"].ToString());
          }
        }
        con.Close();
      }
