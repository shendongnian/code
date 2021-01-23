    public class ViewModelBase {
        public int AuthorId { get; set; }
    
        [ForeignKey(nameof(AuthorId))]
        public virtual User Author { get; set; }
    }
