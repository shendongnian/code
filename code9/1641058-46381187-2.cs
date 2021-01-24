    public static class MyExtensions {
      public static IEnumerable<Control> GetAllControls(this Control control)
      {
        foreach (Control c in control.Controls)
        {
          yield return c;
          foreach (Control c1 in c.GetAllControls())
            yield return c1;
          }
        }
        public static List<T> GetList(this SqlConnection con, string query)
        {
          var list = new List<T>();
          con.Open();
          using(var cmd=new SqlCommand(query,con))
          using(var dr=cmd.ExecuteReader())
          {
            while(dr.Read())
            {
              list.Add((T)dr[0]);
            }
          }
         con.Close();
         return list;
       }
    }
