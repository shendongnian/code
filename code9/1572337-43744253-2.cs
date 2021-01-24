    public class test
    {
        public string app_id { get; set; }
        public string app_os { get; set; }
        public string date { get; set; }
        public string users { get; set; }
    }
    List<test> list = new List<test>();
    using (SqlDataReader rdr = command.ExecuteReader())
    {
        while (rdr.Read())
        {
            test ob = new test();
            ob.app_id = rdr["app_id"].ToString();
            ob.app_os = rdr["app_os"].ToString();
            ob.date = rdr["date"].ToString();
            ob.users = rdr["users"].ToString();
            list.Add(ob);
        }
    }
