    TextBox txtName = (TextBox)e.Item.Cells[1].Controls[0];
    TextBox txtEnglish = (TextBox)e.Item.Cells[2].Controls[0];
    TextBox txtComputer = (TextBox)e.Item.Cells[3].Controls[0];
    
    string strSQL = 
      //DONE: Make SQL readable with a help of string interpolation and verbatim strings  
      $@"update Student 
            set Name     = '{txtName.Text}',
                English  = '{txtEnglish}',
                Computer = '{txtComputer}' 
          where RollNo   = {DataGrid1.DataKeys[e.Item.ItemIndex].ToString()}";
    
    using (SqlConnection con = new SqlConnection("ConnectionStringHere")) {
      con.Open();
    
      using (SqlCommand mycmd = new SqlCommand(strSQL, con)) {
         mycmd.ExecuteNonQuery();
      }
    }
    
    DataGrid1.EditItemIndex = -1;
    FullupGrid();
