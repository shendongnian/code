    var connStrBldr = new System.Data.SqlClient.SqlConnectionStringBuilder();
    connStrBldr.DataSource = "172.28.40.19\CASINO2008R2";
    connStrBldr.InitialCatalog = "GCVS2_DEV_GHR";
    if (useWindowsAuth) {
        connStrBldr.IntegratedSecurity = true;
    } else {
        connStrBldr.IntegratedSecurity = false;
        connStrBldr.UserID = textBox1.Text;
        connStrBldr.Password = textBox2.Text;
    }
    using (SqlConnection con = new SqlConnection(connStrBldr.ToString())) {
        con.Open();
        //do your lookup on login here
    }
