    [ElasticsearchType(Name = "virksomhed")]
    public class Company
    {
        [Object(Name = "Vrvirksomhed")]
        public Vrvirksomhed Vrvirksomhed { get; set; }
    }
    
    public class Vrvirksomhed
    {
        [Text(Name = "cvrNummer")]
        public string cvrNumber { get; set; }
    }
