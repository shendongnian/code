    using(SqlConnection history= new SqlConnection("Data Source=.;Initial Catalog=db3;Integrated Security=True"))
    {
         history.Open();
         SqlCommand histcmd= new SqlCommand("SELECT salary FROM persontable WHERE (Name = @name)", history);
         histcmd.Parameters.AddWithValue("@name", checkname.text);
         List<string> salaryList = new List<string>();
         using (SqlDataReader DRhistory = histcmd.ExecuteReader())
         {    
             while(DRhistory.Read())
             {
                salaryList.Add(DRhistory.GetString(0));
             }
         }
         combobox.Items.AddRange(salaryList.ToArray());
    
         history.Close();
    }
