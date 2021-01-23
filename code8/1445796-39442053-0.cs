    private void Form1_Load(object sender, EventArgs e)
    {
    CustomerReport crystalReport = new CustomerReport();
    Customers dsCustomers = GetData();
    crystalReport.SetDataSource(dsCustomers);
    this.crystalReportViewer1.ReportSource = crystalReport;
    this.crystalReportViewer1.RefreshReport();
    }
 
    private Customers GetData()
    {
    string constr = @"Data Source=.\Sql2005;Initial Catalog=Northwind;Integrated Security = true";
    using (SqlConnection con = new SqlConnection(constr))
    {
        using (SqlCommand cmd = new SqlCommand("SELECT TOP 20 * FROM Customers"))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (Customers dsCustomers = new Customers())
                {
                    sda.Fill(dsCustomers, "DataTable1");
                    return dsCustomers;
                }
            }
        }
    }
}
