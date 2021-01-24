    public class DocumentSale
    {
        [Key]
        public int Id { get; set; }
        public int? FollowDocumentId { get; set; }
        public int? BaseDocumentId { get; set; }
        public virtual DocumentSale FollowDocument { get; set; }
        public virtual DocumentSale BaseDocument { get; set; }
        [ForeignKey(nameof(FollowDocumentId))]
        public virtual List<DocumentSale> FollowDocuments { get; set; }
        [ForeignKey(nameof(BaseDocumentId))]
        public virtual List<DocumentSale> BaseDocuments { get; set; }
    }
