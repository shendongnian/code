    private void RVWeeklyList_Load(object sender, EventArgs e)
    {
        if (!isReportViewerLoaded)
        {
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 =
                new Microsoft.Reporting.WinForms.ReportDataSource();
            PrintWeeklyListDataSet dataset = new PrintWeeklyListDataSet();
            dataset.BeginInit();
            reportDataSource1.Name = "PrintWeeklyListDS"; //Name of the report dataset in our .RDLC file
            reportDataSource1.Value = dataset.GetPrintWeeklyListData;
            rvWeeklyList.LocalReport.DataSources.Add(reportDataSource1);
            rvWeeklyList.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            rvWeeklyList.LocalReport.ReportEmbeddedResource = "<VisualStudioProjectName>.PrintWeeklyList.rdlc";
            dataset.EndInit();
            PrintWeeklyListDataSetTableAdapters.GetPrintWeeklyListDataTableAdapter pwlTableAdapter =
                new PrintWeeklyListDataSetTableAdapters.GetPrintWeeklyListDataTableAdapter();
            pwlTableAdapter.ClearBeforeFill = true;
            pwlTableAdapter.Fill(dataset.GetPrintWeeklyListData);
            rvWeeklyList.RefreshReport();
            isReportViewerLoaded = true;
        }
    }
