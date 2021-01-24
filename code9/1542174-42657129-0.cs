        private void Chicken()
      {
               using (connection = new SqlConnection(connectionString))
               using (SqlDataAdapter adapter = new SqlDataAdapter("select   Chicken_Name,WithOrWithout_Name,Chicken_Price from  Tbl_Add  a full outer join tbl_Chicken b ON b.Chicken_ID = a.Chicken_ID full outer join Tbl_WithORWithot c ON a.WorWO_ID = c.WithOrWothout_ID ; ", connection))
          {
                DataTable tbl_Chicken = new DataTable();
                connection.Open(); //opens the connection
                adapter.Fill(tbl_Chicken);
                connection.Close(); //Closes the connection
                lst_SHowdata.DataSource = tbl_Chicken; //assigns a datasource
                lst_SHowdata.DisplayMember = "Chicken_Name"; //assigns display
                lst_SHowdata.ValueMember = "Chicken_ID"; //assigns id
                lst_SHowdata.DataBind(); //binds the data to the control
                
                lst_SHowdata2.DataSource = tbl_Chicken;
                lst_SHowdata2.DisplayMember ="Chicken_Price";
                lst_SHowdata2.ValueMember = "Chicken_ID";
                lst_SHowdata2.Databind();
            }
      }
      private void Beef()
      {
        using (connection = new SqlConnection(connectionString))
        using (SqlDataAdapter adapter = new SqlDataAdapter("select Beef_Name,WithOrWithout_Name ,Beef_Price from  Tbl_Add a full outer join Tbl_Beef b ON b.Beef_ID = a.Beef_ID full outer join Tbl_WithORWithout c ON a.WorWO_ID = c.WithOrWothout_ID  ; ", connection))
          {
            DataTable tbl_Beef = new DataTable();
            connection.Open();
            adapter.Fill(tbl_Beef);
            connection.Close();
            lst_SHowdata.DataSource = tbl_Beef
            lst_SHowdata.DisplayMember = "Beef_Name";
            lst_SHowdata.ValueMember = "Beef_ID";
            lst_SHowdata.DataBind();
            
            lst_SHowdata2.DataSource = tbl_Beef;
            lst_SHowdata2.ValueMember = "Beef_ID";
            lst_SHowdata2.DisplayMember = "Beef_Price";
            lst_SHowdata2.DataBind();  
        }     
    }
