    public interface IEntity<TPrimaryKey>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        TPrimaryKey Id { get; set; }
    }
    public class Sample : IEntity
    {
        public Guid Id { get; set; }
        public string Text { get; private set; }   
        public Guid? CreatedByUserId { get; set; }
        public virtual User CreatedByUser { get; set; }     
        public List<SampleItem> SampleItems { get; set; } = new List<SampleItem>();
    }
    public class SampleItem : IEntity
    {
        public Guid Id { get; set; }
        public string Text { get; private set; }   
        public Guid? CreatedByUserId { get; set; }
        public virtual User CreatedByUser { get; set; }     
    }
