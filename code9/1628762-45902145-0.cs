     protected void Btn_additem_Click(object sender, EventArgs e)
     {
         String category = "";
         String itemName = Tb_itemname.Text;
         String code = Tb_itemcode.Text;
         String brand = Tb_brand.Text;
         String serial = Tb_serial.Text;
         String capacity = Tb_capacity.Text;
         String version = Tb_version.Text;
    
         if (Rbl_hardsoft.SelectedValue.Equals("Hardware")) 
         {
             category = "Hardware";
         }
         else if(Rbl_hardsoft.SelectedValue.Equals("Software"))
         {
             category = "Software";
         }
    
         using (SqlConnection connection = new SqlConnection(connectionString))
         using (SqlCommand command = connection.CreateCommand())
         command.CommandText = "INSERT INTO Contacts ItemMasterData(item_code,item_category, item_name, item_brand,item_serialnumber, item_capacity, item_version) VALUES (@item_code,@item_category, @item_name, @item_brand,@item_serialnumber, @item_capacity, @item_version)";
         command.Parameters.AddWithValue("@item_code", code );
         command.Parameters.AddWithValue("@item_category", category );
         command.Parameters.AddWithValue("@item_name", itemName );
         command.Parameters.AddWithValue("@item_brand", brand );
         .. the rest of parameters...
    
        connection.Open();
        command.ExecuteNonQuery();
    }
