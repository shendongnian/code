    private void btnUpdate_Click(object sender, EventArgs e)
        {
                    ServiceReference1.StockList stockDetails = new ServiceReference1.StockList();
    
                    stockDetails.PartNumber = txtPartNumber.Text;
                    stockDetails.Description = txtDescription.Text;
    
                    sList.UpdateStockCard(stockDetails);
    }
