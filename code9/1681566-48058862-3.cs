    private void ViewAvailProd_Btn_Click(object sender, EventArgs e)
    {
        AvailProd_DGV.Rows.Clear();
        foreach (TBL_Product prod in DataLProducts.GetProducts())
        {
            AvailProd_DGV.Rows.Add(prod.ProductID, prod.Name, prod.Category, prod.Price, prod.Stock, "Purchase");
        }
        this.PNL_ViewAvailProd.Visible = true;
    }
