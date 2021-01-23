    public static class Portfolio
    {
        public static IList<string> GetNames()
        {
            SqlConnection myConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Nick\Documents\Investments 4.mdf""; Integrated Security = True; Connect Timeout = 30");
            myConnection.Open();
            SqlCommand myCommand2 = new SqlCommand();
            myCommand2.Connection = myConnection;
            myCommand2.CommandText = "SELECT Portfolio_Name FROM Dbo.Name WHERE In_use = 1";
            SqlDataReader myReader2 = myCommand2.ExecuteReader();
            var portfolioNames = new List<string>();
            while (myReader2.Read())
            {
                portfolioNames.Add(myReader2[0]);
            }
            myConnection.Close();
            return portfolioNames;
        }
     }
