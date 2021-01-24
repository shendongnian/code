    public class ParentModel
    {
        public ParentModel() {
            ChildModelList = new List<ChildModel>();
        }
        //and even a ctor  with a given number to instanciate ChildModel
        public ParentModel(int childNumber) : this() {
            ChildModel = new ChildModel{Number = childNumber};
        }
        public int Id { get; set; }
        public string Name { get; set; }
    
        public ChildModel ChildModel { get; set; }
        public List<ChildModel> ChildModelList { get; set; }
    }
