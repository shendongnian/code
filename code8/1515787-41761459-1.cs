        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            SqlDataSource sqldsInsertPassword = new SqlDataSource();
            sqldsInsertPassword.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            sqldsInsertPassword.ProviderName = ConfigurationManager.ConnectionStrings["ConnectionString"].ProviderName;
            sqldsInsertPassword.InsertCommand = "INSERT INTO Image (Name) VALUES (@Name)";
            sqldsInsertPassword.InsertCommandType = SqlDataSourceCommandType.Text;
            sqldsInsertPassword.InsertParameters.Add("Name", e.Values[0].ToString());
            sqldsInsertPassword.Insert();
        }
