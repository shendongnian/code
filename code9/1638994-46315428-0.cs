    public class Email
    {
        public int Id { get; set; }
        [ForeignKey("EmailTemplate")]
        public int? EmailTemplateId { get; set; }
        public virtual EmailTemplate EmailTemplate { get; set; }
    }
