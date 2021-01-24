    public class ChildModel
    {
        ...properties here
    
        //relationship to parent
        public int? ParentModelID { get; set; }
        [ForeignKey("ParentModelID")]
        public ParentModel ParentModel { get; set; }
    }
