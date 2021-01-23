    [Table("MetaDataPair")]
    public class DbMetaDataPair : IEntityComparable<DbMetaDataPair>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Key { get; set; }
        public string Value { get; set; }
        // this is the navigation property back up to the ObjectChild
        public virtual ObjectChild ObjectChild { get;set; }
    }
    public ObjectChild
    {
        ...
        public ICollection<MetaDataPair> MetaDataPairs { get; set; }
        // this is the navigation property back up to the "Object"
        public virtual Object Object { get; set; }
        ...
    }
