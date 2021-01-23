    public bool VerifyUser(string userId, string password)
        {
            DBFunctions dbInfo = new DBFunctions();
            bool status = false;
            string verifyUserQry = "SELECT * FROM Employee WHERE UserName = '" + userId + "' AND Password = '" + password + "'";
            DataTable dt = default(DataTable);
            dt = dbInfo.OpenDTConnection(verifyUserQry);
            if (dt.Rows.Count == 1)
            {
