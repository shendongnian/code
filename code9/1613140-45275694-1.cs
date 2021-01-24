    [Route("api/SalesReport", Name = "salesReport")]
    public void PostUpdate([FromBody]SalesReportData value)
    {
        SalesDBConn db = new SalesDBConn();
        db.addSalesReport(value.connectionString, value.SalesReport);
    }
    //rename the class 
    public class SalesReportData{
    public string connectionString {get; set; }
    public string SalesReport {get; set; }
    }
