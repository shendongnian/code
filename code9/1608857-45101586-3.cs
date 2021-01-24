    TextBox txtName = (TextBox)e.Item.Cells[1].Controls[0];
    TextBox txtEnglish = (TextBox)e.Item.Cells[2].Controls[0];
    TextBox txtComputer = (TextBox)e.Item.Cells[3].Controls[0];
    
    string strSQL = 
      $@"update Student 
            set Name     = :prm_Name,
                English  = :prm_English,
                Computer = :prm_Computer 
          where RollNo   = :prm_RollNo";
    
    using (SqlConnection con = new SqlConnection("ConnectionStringHere")) {
      con.Open();
    
      using (SqlCommand mycmd = new SqlCommand(strSQL, con)) {
        //TODO: a better choice is to create parameter with specified RDMBS type
        mycmd.Parameters.AddWithValue(":prm_Name", txtName.Text);         
        mycmd.Parameters.AddWithValue(":prm_English", txtEnglish);         
        mycmd.Parameters.AddWithValue(":prm_Computer", txtComputer);         
        mycmd.Parameters.AddWithValue(":prm_RollNo", 
          DataGrid1.DataKeys[e.Item.ItemIndex].ToString());         
    
        mycmd.ExecuteNonQuery();
      }
    }
    
    DataGrid1.EditItemIndex = -1;
    FullupGrid();
