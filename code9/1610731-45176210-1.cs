    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int BatchID = (int)GridView1.DataKeys[GridView1.SelectedIndex].Value;
        //Access Ingredients with batchID
        var dtIngredients = new DataTable(); // create datasource with a query
        GridView2.Visible = true;
        GridView2.DataSource = dtIngredients;
        GridView2.DataBind();
    }
