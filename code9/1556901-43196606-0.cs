    public abstract class ItemExtension
    {
        [Required]
        public virtual Guid ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
