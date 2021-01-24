    private void AddProductsToTab()
    {
        int i = 1;
        foreach (AjaxControlToolkit.TabPanel tp in TabContainer1.Tabs)
        {
            ObjectContext objectContext = ((IObjectContextAdapter)rdb).ObjectContext; //we cast our database to an object context, so we can use it in the ObjectQuery.
            ObjectQuery<tblProduct> filteredProduct = new ObjectQuery<tblProduct>("SELECT VALUE P FROM tblProducts AS P WHERE P.ProductType = " + i.ToString(),objectContext);
            foreach (tblProduct tprod in filteredProduct)
            {
                Button b = new Button();
                b.Height = 100;
                b.Width=100;
                b.Text = tprod.Description;
                b.CssClass = "product-button";
                b.Attributes["data-name"] = tprod.Name;
                b.Attributes["data-price"] = tprod.Price;
                tp.Controls.Add(b);
            }
            i++;
        }
    }
