    public partial class JOBLINE
    {
        [Key, Column(Order = 0)]
        public int JobNumber {get;set;}
        [Key, Column(Order = 1)]
        public int LineNumber {get;set;}
    
        [Index("IX_LineTypeAndLineCode", 1, IsUnique = true)]
        public string LineType {get;set;} 
    
        [Index("IX_LineTypeAndLineCode", 2, IsUnique = true)]
        public string LineCode {get;set;}
    }
