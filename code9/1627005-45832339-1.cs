    public class MainViewModel
    {
        public CrystalDecisions.CrystalReports.Engine.ReportDocument Report { get; set; }
    
        public MainViewModel()
        {
            Report = new NameOfRptFile();
            //Add data to the report
        }
    }
