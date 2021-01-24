        SqlConnection cn = new SqlConnection(strCn);
        try
        {
            using (SqlCommand cmd = new SqlCommand("select * from xxxx", cn))
            {
                cn.Open();
                //do something
                cn.Close();
            }
        }
        catch (Exception exception)
        {
            cn.Close();
            throw exception;
        }
