    GridViewRow gr1 = GridView1.SelectedRow;
        Label lblProdID = gr1.FindControl("Label1") as Label;
        SqlDataSource3.InsertParameters["OrderDate"].DefaultValue = "11/06/2017";
        SqlDataSource3.InsertParameters["CustID"].DefaultValue = TextBox2.Text;
        SqlDataSource3.InsertParameters["OrderID"].DefaultValue = "12346";
        SqlDataSource3.InsertParameters["ProdID"].DefaultValue = lblProdID.Text;
        SqlDataSource3.InsertParameters["OrderQty"].DefaultValue = ((TextBox)gr1.FindControl("TextBox1")).Text;
        SqlDataSource3.Insert();
