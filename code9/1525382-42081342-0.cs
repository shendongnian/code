            try
            {
                //long Beneficiary_ID = 0;
                //string BeneficiaryID = "";
                ArrayList BeneficiaryArray = new ArrayList();
                // Open connection to the database
                string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Databasebcfintec_alice"].ConnectionString;
                aConn = new SqlConnection(strConn);
                aConn.Open();
                // Set up a command with the given query and associate
                // this with the current connection.
                string sql = "Select BeneficiaryID from Beneficiary where user_id = '" + UserID + "'";
                cmd = new SqlCommand(sql);
                cmd.Connection = aConn;
                // Execute the query
                odtr = cmd.ExecuteReader();
                while (odtr.Read())
                {
                    BeneficiaryArray.Add(odtr["BeneficiaryID"]);
                    //User_ID = (long)(odtr["user_id"]);
                    //UserID = User_ID.ToString();
                }
                odtr.Close();
                return BeneficiaryArray;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
               throw ex;
            }
}
