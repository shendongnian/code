    public class ClusterVM {
        public ClusterVM() {
            this.Attributes = new Dictionary<Guid, AttributeVM>();
        }
        public IDictionary<Guid,AttributeVM> Attributes { get; set; }
        public  void AddAttribute(Guid guid, string name) {
            AttributeVM attrVM = new AttributeVM();
            attrVM.Name = name;
            attrVM.Guid = guid;
            this.Attributes.Add(guid,attrVM);
        }
    }
