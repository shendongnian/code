    private void GetUserELO(int UserID, ref double Elo)
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlStr;
            dbConnector.Connect();
            sqlStr = "SELECT Users.Elo FROM Users WHERE UserID = " + UserID + "";
            dr = dbConnector.DoSQL(sqlStr);
            while (dr.Read())
            {
                string Elo1 = dr.GetValue(0).ToString();
                MessageBox.Show("User Added" + UserID, "Sucessfully Added User" + 
                Elo1,
                MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
