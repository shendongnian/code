    string SQL = @"SELECT Product, Price FROM Supplies"; 
    using (SqlCommand cmd = new SqlCommand(SQL, con))
    { 
     using (SqlDataReader dr = cmd.ExecuteReader()) 
     { 
      ddlProduct.DataSource = dr;
      ddlProduct.DataTextField = "Product";
      ddlProduct.DataValueField = "Price ";
      ddlProduct.DataBind(); 
      ddlProduct.Items.Insert(0, new ListItem("Select one...", "")); 
     } 
