        void Fillcombo()
        {
            cbxProducts.Text = "";
            cbxProducts.Items.Clear();
            string constring = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = \"C:\\Users\\hannes.corbett\\Desktop\\Barcode Scanning\\Barcode Scanning\\BarcodeDB.mdf\"; Integrated Security = True";
            string Query = "SELECT Name FROM Products ORDER BY EDate;";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDataBase = new SqlCommand(Query, conDataBase);
            SqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    
                    string sName = myReader.GetString(myReader.GetOrdinal("Name"));
                    cbxProducts.Items.Add(sName);
                    cbxProducts.Sorted = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
