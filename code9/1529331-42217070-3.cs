        SqlConnection con = new SqlConnection("Data Source=5CG50749V3\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True");
    
        SqlDataAdapter sda = new SqlDataAdapter("Select * FROM [Equipment] WHERE SerialNumber='" + SerialNumber.Text + "' or EquipmentID ='" + EquipmentID.Text + "'", con);
    
        DataTable dt = new DataTable();
        sda.Fill(dt);
       
           if (dt.Rows.Count != 0) // this will check weather any records are returned
               {
                   // If record is found
                  SerialNumber.Text = dt.Rows[0][5].ToString();
                  EquipmentID.Text = dt.Rows[0][4].ToString();
               }
            else //if no record is found it will display alert
                 {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('no record found');", true);
                 }
