    public List<Menu> Getmonan()
    {
        string cs = ConfigurationManager.ConnectionStrings["RestaurantConnection"].ConnectionString;
        List<Menu> menulist = new List<Menu>();
        // Menu menu = new Menu();  // <--- remove this!!
        using (SqlConnection conn = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("Getmenu", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Menu menu = new Menu();   // <--- put it here...
                menu.Tenmon = reader["TenMon"].ToString();
                menu.Loaimon = reader["LoaiMon"].ToString();
                menulist.Add(menu);
            }
        }
        return menulist;
    }
