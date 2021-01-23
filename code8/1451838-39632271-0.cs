    SqlParameter[] param =
    {
        new SqlParameter("@logintype",com.ToString()),
        new SqlParameter("@name",lblempname.Text),
        new SqlParameter("@datefrm",SqlDbType.DateTime{Value=dateFrom }),
        new SqlParameter("@dateto", SqlDbType.DateTime{ Value = dateTo })
    };
    
