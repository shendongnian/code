    var dtStock = new DataTable("Stock");
    MyCommand.CommandType = CommandType.Text;
    myDA.SelectCommand = MyCommand;
    myDA.Fill(dtStock, "Stock");
    // another command for Stock_Product
    var dtStockProduct =new DataTable("Stock_Product");
    stockProductDA.SelectCommand = StockProductCommand;
    stockProductDA.Fill(dtStockProduct, "Stock_Product");
    // fill all the tables
    
    // finally, add all the tables to your data set
    myDS.Tables.Add(dtStock);
    myDS.Tables.Add(dtStockProduct);
    // continue as normal
    rd.Load(@"C:\Users\aliali\Documents\Visual Studio 2013\Projects\GenesysInventory System\GenesysInventory System\rptpurchase.rpt");
    rd.SetDataSource(myDS);
    
    frmReport obj = new frmReport();
    obj.crystalReportViewer1.ReportSource = rd;
    obj.ShowDialog();
