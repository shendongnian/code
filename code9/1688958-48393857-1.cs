    private void btnUpdate_Click(object sender, EventArgs e)
        {
                    ServiceReference1.StockList stockDetails = new ServiceReference1.StockList();
    
                stockDetails.CategoryName = txtID.Text;
                stockDetails.MainGroupName = txtOPCOID.Text;
                stockDetails.SubGroupName = txtSubGroupID.Text;
                stockDetails.IDNumber = txtIDNumber.Text;
                stockDetails.PartNumber = txtPartNumber.Text;
    
                    sList.UpdateStockCard(stockDetails);
    }
