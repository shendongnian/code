            public class TPCase
            {
                [Key, Column(Order = 0)]
                public string BusinessSystemId { get; set; }
    
                [Key, Column(Order = 1)]
                public int CaseId { get; set; }
    
                public virtual ICollection<TPCaseName> CaseNames { get; set; }
            }
    
            public class TPCaseName
            {
                [Key, Column(Order = 0)]
                public string BusinessSystemId { get; set; }
    
                [Key, Column(Order = 1)]
                public int CaseId { get; set; }
    
                [Key, Column(Order = 2)]
                public int NameNo { get; set; }
    
                [Key, Column(Order = 3)]
                public string NameType { get; set; }
    
    
                [ForeignKey("BusinessSystemId,CaseId")]
                public virtual TPCase TPCase { get; set; }
    
                [ForeignKey("BusinessSystemId,NameNo")]
                public virtual TPName TPName { get; set; }
    
                //[ForeignKey("NameType")]
                // public virtual TPNameType TPNameType { get; set; }
                public string ContactName { get; set; }
            }
    
            public class TPName
            {
                [Key, Column(Order = 0)]
                public string BusinessSystemId { get; set; }
    
                [Key, Column(Order = 1)]
                public int NameNo { get; set; }
    
                public string NameCode { get; set; }
            }
