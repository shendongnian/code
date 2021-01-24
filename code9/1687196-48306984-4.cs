    public class Noaa
    {
        public MetaData metadata {get;set;}
        public List<Result> results;
    }
    
    public class MetaData 
    {
        public ResultSet resultset {get;set;}
    }
    
    public class ResultSet
    {
       public int offset{get;set;}
       public int count{get;set;}
       public int limit{get;set;}
    }
           
    [DataContract]
    public class Result
    {
        [DataMember(Name="date")]
        public string Date { get; set; } // now a string!
        [DataMember(Name="datatype")]
        public string DataType { get; set; }
        [DataMember(Name="station")]
        public string Station { get; set; }
        [DataMember(Name="attributes")]
        public string Attributes { get; set; }
        [DataMember(Name="value")]
        public int Value { get; set; }
    }
