    using (SqlCommand cmd = new SqlCommand(tmp, con))
    {
        cmd.CommandType = CommandType.Text;
        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        {
    
        }
    }
