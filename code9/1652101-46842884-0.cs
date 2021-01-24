    public class MainModel
    {
        public MainModel()
        {
            ChildModels= new HashSet<ChildModel>();
        }
        public int Id { get; set; }
        public virtual ICollection<ChildModel> ChildModels{ get; set; }
    }
    public class ChildModel
    {
        public int Id { get; set; }
        public int? MainModelId { get; set; }
        public MainModel MainModel { get; set; }
    }
