    public List<Menu> Getmonan()
    {
        string cs = ConfigurationManager.ConnectionStrings["RestaurantConnection"].ConnectionString;
        List<Menu> menulist = new List<Menu>();
        using (SqlConnection conn = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("Getmenu", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while(sdr.Read())
            {
                Menu menu = new Menu()
               {
                 Tenmon = sdr.GetString(Column Index);
                 Loaimon = sdr.GetString(Column Index);
               };
                menulist.Add(menu);
            }
        }
        return menulist;
    }
