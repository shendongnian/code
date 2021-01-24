    public class ReportGenerationResult { }
    public class DataObj { }
    public class ReportConfig<T> where T : class
    {
        public string ReportSavePath { get; set; }
        public string ReportTitle { get; set; }
        public T ReportData { get; set; }
    }
    public class CsvReportConfig<T> : ReportConfig<T> where T : class
    {}
    public abstract class ReportGenerator<T,U> where T : ReportConfig<U> where U : class
    {
        protected ReportGenerator(T config)
        {
            Config = config;
        }
        public T Config { get; set; }
        public abstract ReportGenerationResult GenerateReport();
    }
    public class Csv1ReportGenerator : ReportGenerator<CsvReportConfig<DataObj>, DataObj>
    {
        public Csv1ReportGenerator(CsvReportConfig<DataObj> config) : base(config)
        {
        }
        public override ReportGenerationResult GenerateReport()
        {
            throw new NotImplementedException();
        }
    }
