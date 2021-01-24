        private void InsertRecords(StringCollection sc)
        {
            const string sqlStatement = "INSERT INTO Ingredients_List (Ingredients1) VALUES";
            StringBuilder sb = new StringBuilder();
            foreach (string item in sc)
            {
                if (item.Contains(","))
                {
                    var splitItems = item.Split(",".ToCharArray());
                    sb.AppendFormat("{0}('{1}'); ", sqlStatement, splitItems[0]);
                }
            }
            Console.WriteLine(sb.ToString());
            //  conn.Open();
            using (SqlConnection connn = new SqlConnection(ConfigurationManager.ConnectionStrings["whatever"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sb.ToString(), connn))
                {
                    connn.Open();
                    cmd.ExecuteNonQuery();
                    connn.Close();
                }
                // Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records Successfuly Saved!');", true);
            }
        }
