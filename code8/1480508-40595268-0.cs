     public class VariantProperty
    {
        public string geneName { get; set; }
        public string isVUS { get; set; }
        public string variantName { get; set; }
    }
    public class VariantProperties
    {
        public List<VariantProperty> VariantProperty { get; set; }
    }
    public class FinalReport
    {
        public Object Application { get; set; }
        public string ReportId { get; set; }
        public string SampleName { get; set; }
        public string Version { get; set; }
        public Object Sample { get; set; }
        public string PertinentNegatives { get; set; }
        public Object Summaries { get; set; }
        public VariantProperties VariantProperties { get; set; }
        public Object Genes { get; set; }
        public Object Trials { get; set; }
        public Object References { get; set; }
        public Object Signatures { get; set; }
        public Object AAC { get; set; }
    }
    public class ResultsReport
    {
        public FinalReport FinalReport { get; set; }
    }
    public class RootObject
    {
        public ResultsReport ResultsReport { get; set; }
    }
