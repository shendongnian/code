    using(SqlConnection con = new SqlConnection("your conn"))
    {
        con.Open();
        string sql = "SELECT MA_BO_CAU_HOI FROM R_NGUOICHOI_BOCAUHOI where MA_NGUOI_CHOI=@Param1";
        
        DataTable data = new DataTable();
        using(SqlDataAdapter adapter = new SqlDataAdapter())
        {
             SqlCommand cmd = new SqlCommand(sql, con);
             cmd.Parameters.AddWithValue("@Param1", cbbten.SelectedIndex);
             adapter.SelectCommand = cmd;
    
             adapter.Fill(data);         
        }
    }
