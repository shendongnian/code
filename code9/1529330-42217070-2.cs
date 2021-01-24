        SqlConnection con = new SqlConnection("Data Source=5CG50749V3\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True");
    
        SqlDataAdapter sda = new SqlDataAdapter("Select * FROM [Equipment] WHERE SerialNumber='" + SerialNumber.Text + "' or EquipmentID ='" + EquipmentID.Text + "'", con);
    
        DataTable dt = new DataTable();
        sda.Fill(dt);
        string serial = dt.Rows[0][5].ToString();
        string Id = dt.Rows[0][4].ToString();
           if (serial !=null || Id != null) // this will check weather any records are returned
               {
                   // If record is found
                  SerialNumber.Text = serial ;
                  EquipmentID.Text = Id ;
               }
            else //if no record is found it will display alert
                 {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('no record found');", true);
                 }
