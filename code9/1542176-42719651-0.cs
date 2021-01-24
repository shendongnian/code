    private void Beef()
            {
    
                using (connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter= new SqlDataAdapter("select Beef_Name,WithOrWithout_Name ,Beef_Price from  Tbl_Add a full outer join Tbl_Beef b ON b.Beef_ID = a.Beef_ID full outer join Tbl_WithORWithot c ON a.WorWO_ID = c.WithOrWothout_ID  ; ", connection))
                {
                    
    
                    DataTable Tbl_Beef = new DataTable();
                    connection.Open(); 
                    adapter.Fill(Tbl_Beef);
                    connection.Close();
    
                    lst_SHowdata.DataSource = Tbl_Beef; 
                    lst_SHowdata.DisplayMember = "Beef_Name";
                                                             
                    lstSHowdata2.DataSource = Tbl_Beef; 
                    lstSHowdata2.DisplayMember = "Beef_Price";
    
    
                }     
            }
