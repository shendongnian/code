        private void button1_Click_1(object sender, EventArgs e)
        {
            string iOne = dgMasterGridView.SelectedRows[0].Cells[1].Value + string.Empty;
            string iTwo = dgMasterGridView.SelectedRows[0].Cells[2].Value + string.Empty;
            string iThree = dgMasterGridView.SelectedRows[0].Cells[3].Value + string.Empty;
            string iFour = dgMasterGridView.SelectedRows[0].Cells[4].Value + string.Empty;
            string iFive = dgMasterGridView.SelectedRows[0].Cells[5].Value + string.Empty;
            string iSix = dgMasterGridView.SelectedRows[0].Cells[6].Value + string.Empty;
            string iSeven = dgMasterGridView.SelectedRows[0].Cells[7].Value + string.Empty;
            string iEight = dgMasterGridView.SelectedRows[0].Cells[8].Value + string.Empty;
            string iNine = dgMasterGridView.SelectedRows[0].Cells[9].Value + string.Empty;
            string iTen = dgMasterGridView.SelectedRows[0].Cells[10].Value + string.Empty;
            string iEleven = dgMasterGridView.SelectedRows[0].Cells[11].Value + string.Empty;
            string iTwelve = dgMasterGridView.SelectedRows[0].Cells[12].Value + string.Empty;
            try
            {
                // Connection to DB
                SqlConnection con = new SqlConnection();
                con.ConnectionString = (@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Database;Integrated Security=True");
                //Insert Query
                string insertquery = "INSERT INTO dbo.[myTable] ([Item1], [Item2], [Item3], [Item4], [Item5], [Item6], [Item7], [Item8], [Item9], [Item10], [Item11], [Item12]) VALUES(@Item1,@Item2,@Item3,@Item4,@Item5,@Item6,@Item7,@Item8,@Item9,@Item10,@Item11,@Item12)";
                SqlCommand cmd = new SqlCommand(insertquery, con);
                //open connection
                con.Open();
                //Parameters
                cmd.Parameters.AddWithValue("@Item1", iOne);
                cmd.Parameters.AddWithValue("@Item2", iTwo);
                cmd.Parameters.AddWithValue("@Item3", iThree);
                cmd.Parameters.AddWithValue("@Item4", iFour);
                cmd.Parameters.AddWithValue("@Item5", iFive);
                cmd.Parameters.AddWithValue("@Item6", iSix);
                cmd.Parameters.AddWithValue("@Item7", iSeven);
                cmd.Parameters.AddWithValue("@Item8", iEight);
                cmd.Parameters.AddWithValue("@Item9", iNine);
                cmd.Parameters.AddWithValue("@Item10", iTen);
                cmd.Parameters.AddWithValue("@Item11", iEleven);
                cmd.Parameters.AddWithValue("@Item12", iTwelve);
                //execute
                cmd.ExecuteNonQuery();
                //close connection
                con.Close();
                MessageBox.Show("Information has been submitted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
