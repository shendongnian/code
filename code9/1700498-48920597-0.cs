        private void Form_Load(object sender, EventArgs e)
        {
            rptViewerMain.LocalReport.ReportEmbeddedResource = "MyProjectName.QuotationReport.rdlc";
            rptViewerMain.LocalReport.EnableExternalImages = true;
            if (QuotationInfo !=null && QuotationItems != null)
            {
                SetupReport();
            }
            this.rptViewerMain.RefreshReport();
        }
        private void SetupReport()
        {
            var param1 = new ReportParameter("MyFirstParameter", SomeValue);
            var param2 = new ReportParameter("MySecondParameter", SomeOtherValue);
            // etc
            // Pass Parameters
            rptViewerMain.LocalReport.SetParameters(new[] { param1, param2, "etc" });
            // Prepare the DataTable and add the values to it
            DataTable dt = new MyDummyDataset.MyDesignedDataTable().Clone();
            foreach (var qItem in QuotationItems)
            {
                dt.Rows.Add(qItem.ItemNumber, qItem.ItemDescription, "and",
                            "so", "many", "more", "values");
            }
            // Pass the DataTable to the report as the data source replacing the dummy DataSet
            rptViewerMain.LocalReport.DataSources.Add(new ReportDataSource("MyDummyDataset", dt));
        }
