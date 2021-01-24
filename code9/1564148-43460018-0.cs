    public class ChildTable : EntityBase {
        private string _someCategory;
        [Key]
        [Column(name: "CHILD_ID")]
        public override int Id { get; protected set; }
        [Column(name: "SOME_CATEGORY")]
        public string SomeCategory {
            get { return _someCategory; }
            set { _someCategory = value ?? ParentTable.SomeCategory; }
        }
        [ForeignKey("ParentTable")]
        [Column(name: "PARENT_ID")]
        public int ParentTableId { get; set; }
        public virtual ParentTable ParentTable { get; set; }
    }
