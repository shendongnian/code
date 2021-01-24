    var query = "SELECT * FROM freeGiftOffers WHERE ID = @ID";
    var conString = ConfigurationManager.ConnectionStrings("conio2").ConnectionString;
    using (var con = new MySqlConnection(conString)) 
    using (var cmd = new MySqlCommand(query)) 
    using (var sda = new MySqlDataAdapter())  {
        
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Connection = con;
        sda.SelectCommand = cmd;
    
        using (DataTable dt = new DataTable()) {
            sda.Fill(dt);
            if (!dt.Rows.Any()) { return; }
    
            var selectedProductList1 = dt.Rows(0)("productID").ToString();    
            drpProductsList.ClearSelection();    
            drpProductsList.Items.FindByValue(selectedProductList1).Selected = true;
    
            var selectedProductList2 = dt.Rows(0)("freeProductID").ToString();
            drpProductsList2.ClearSelection();
            drpProductsList2.Items.FindByValue(selectedProductList2).Selected = true;     
        }
    }
    
