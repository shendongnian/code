    //
    // define and initialize variables
    //
    string credentials = null;
    SqlConnection sqlserv = null;
    string lv_string = null;
    SqlCommand collections_cur = null;
    SqlCommand headings_cur = null;
    int cl_idno = 0;
    
    //
    // connect to database
    // MultipleActiveResultSets=True was added
    // to allow usage of multiple cursors
    //
    credentials = "Data Source=(localdb)\\MSSQLLocalDB;" +
                  "Initial Catalog=rescratch;" +
                  "Integrated Security=True;" +
                  "Connect Timeout=30;" +
                  "Encrypt=False;" +
                  "TrustServerCertificate=True;" +
                  "ApplicationIntent=ReadWrite;" +
                  "MultipleActiveResultSets=True;" +
                  "MultiSubnetFailover=False";
    sqlserv = new SqlConnection(credentials);
    sqlserv.Open();
    //
    // declare cursors
    //
    
    lv_string = " select * from collections " +
                " where cl_idno >= @cl_idno ";
    collections_cur = new SqlCommand(lv_string, gv_sqlserv);
    collections_cur.Parameters.Add(new SqlParameters("cl_idno", 0));
    lv_string = " select * from headings " +
                " where hd_cl_idno = @hd_cl_idno ";
    headings_cur = new SqlCommand(lv_string, gv_sqlserv);
    headings_cur.Parameters.Add(new SqlParameters("hd_cl_idno", 0));
    //
    // main cursor
    //
    // set parameter
    collections_cur.Parameters["cl_idno"].Value = 1;
    using(SqlDataReader lv_reader1 = collections_cur.ExecuteReader())
    {
    
        while(lv_reader1.Read())
        {
    
            // some stuff
    
            cl_idno = lv_reader1.GetInt32(0);
            //
            // sub cursor
            //
    
            // set parameter
            headings_cur.Parameters["hd_cl_idno"].Value = cl_idno;
            using(SqlDataReader lv_reader2 = headings_cur.ExecuteReader())
            {
    
                while(lv_reader2.Read())
                {
    
                    // more stuff
    
                }
    
            }
        }
    
    }
    
    sqlserv.Close();
