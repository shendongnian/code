    public class Document
    {
        public int Id { get; set; }
    
        public virtual Document Parent { get; set; }
        public int ParentId { get; set; }
    
        public virtual Document SrcDocument { get; set; }
        public int SrcDocumentId { get; set; }
    
        [InverseProperty("Parent")]
        public virtual ICollection<Document> Children {get;set;}
        [InverseProperty("SrcDocument")]
        public virtual ICollection<Document> Derived {get;set;}
    }
