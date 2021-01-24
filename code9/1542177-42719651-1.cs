     private void Chicken()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("select * from  Tbl_Add  a full outer join tbl_Chicken b ON b.Chicken_ID = a.Chicken_ID full outer join Tbl_WithORWithot c ON a.WorWO_ID = c.WithOrWothout_ID ; ", connection))
            {
                DataTable tbl_Chicken = new DataTable();
                connection.Open(); //opens the connection
                adapter.Fill(tbl_Chicken);
                connection.Close(); //Closes the connection
    
                lst_Menu.DataSource = tbl_Chicken; //assigns a datasource
                lst_Menu.DisplayMember = "Chicken_Name"; //assigns display
                lst_Menu.ValueMember = "Chicken_Name";
    
                lst_worwout.DataSource = tbl_Chicken;
                lst_worwout.DisplayMember = "WithOrWithout_Name";
                lst_worwout.ValueMember = "WithOrWithout_Name";
    
                lst_Price.DataSource = tbl_Chicken;
                lst_Price.DisplayMember = "Chicken_Price";
                lst_Price.ValueMember = "Chicken_Price";
    
    
            }
        }
