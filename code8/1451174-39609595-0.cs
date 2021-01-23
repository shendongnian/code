    private void CrystalFormView_Load(object sender, EventArgs e)
    {
      string connection = ConfigurationManager.ConnectionStrings["sqlbill"].ConnectionString;
      string provider = ConfigurationManager.ConnectionStrings["sqlbill"].ProviderName;
      SqlConnection con = new SqlConnection(connection);
      SqlDataAdapter sda = new SqlDataAdapter("select product as Product,productid as ProductId,quantity as Quantity from productdata", con);
      DataSet ds = new DataSet();
      sda.Fill(ds);
      ds.Tables[0].TableName = "BILLTEST";
      
      BillCrystalReport bill = new BillCrystalReport();  
      bill.SetDataSource(ds);
      bill.VerifyDatabase();
      crystalReportViewer1.ReportSource = bill;
      crystalReportViewer1.RefreshReport();
    }
