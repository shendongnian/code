    protected void Page_Load(object sender, EventArgs e)
    {
        AuditNLoggingDAO al = new AuditNLoggingDAO();
        int result = 0;
        int resultLogout = 0;
        //Get IP Address of Client's Machine
        String externalIP = null;
        try
        {
            externalIP = (new WebClient()).DownloadString("http://checkip.dyndns.org/");
            externalIP = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")).Matches(externalIP)[0].ToString();
        }
        catch (Exception ex)
        {
            logManager log = new logManager();
            log.addLog("Retrieval of IP Address", "IP Address", ex);
        }
        CultureInfo provider = CultureInfo.InvariantCulture;
        if (!String.IsNullOrEmpty(Session["LoginUserName"].ToString()))
        {
            String loginUsername = Session["LoginUserName"].ToString();
            //Get latest Login time
            DataSet ds = new DataSet();
            ds = al.getAuditData(Session["LoginUserName"].ToString());
            DateTime dateTimeOfLatestLogin = DateTime.MinValue;
            /*foreach (DataRow r in ds.Tables[0].Rows)
            {
                //dateTimeOfLatestLogin = DateTime.ParseExact(r["LastLoginTime"].ToString(), "dd-MM-yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                String dtDBString = r["LastLoginTime"].ToString();
                dateTimeOfLatestLogin = Convert.ToDateTime(dtDBString);
                //Debug.WriteLine(dateTimeOfLatestLogin);
                //"MM-dd-yyyy HH:mm:ss tt"
            }*/
            String DBConnectionStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection connection = new SqlConnection(DBConnectionStr);
            string sql = "select LastLoginTime FROM AuditTrails WHERE Username=@USERID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@USERID", loginUsername);
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string timeTaken = reader["LastLoginTime"].ToString();
                        dateTimeOfLatestLogin = Convert.ToDateTime(timeTaken);
                    }
                }
                connection.Close();
            }
            catch (SqlException ex)
            {
                logManager log = new logManager();
                log.addLog("LogoutWithDesc.aspx.cs", "PageLoad", ex);
            }
            resultLogout = al.updateLLogoutT(loginUsername, DateTime.Now, externalIP);
            result = al.trackLogout(loginUsername, externalIP, Convert.ToDouble(latitudeTB.Value), Convert.ToDouble(longitudeTB.Value));
            loginDetails.InnerText = "You logged into your account at " + dateTimeOfLatestLogin.ToString("hh:mm:ss tt dd/MM/yyyy") + " SGT.";
            logoutDetails.InnerText = "You logged out from your session at " + (DateTime.Now).ToString("hh:mm:ss tt dd/MM/yyyy") + " SGT.";
        }     
    }
