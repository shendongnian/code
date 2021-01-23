    using Microsoft.Reporting.WebForms;
    
    protected void Form_Load(Object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report.rdlc");
    
            // add your DataSet here
    
            var data = new DataTable(); // example data source
            var dataSource = new ReportDataSource(DataSetName, data);
    
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
            // put rendering stuff here
        }
    }
