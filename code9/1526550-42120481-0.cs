    public partial class Report_View : Window
    {
        public Report_View(string param1, string reportName)
        {
    		System.Diagnostics.PresentationTraceSources.DataBindingSource.Switch.Level = System.Diagnostics.SourceLevels.Critical;
            CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            reportDocument.Load(reportName);
            ...
