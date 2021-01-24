    public class Model {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasChildren => this.Children != null && this.Children.Count > 0;
        public ICollection<ChildModel> Children { get; set; }
    }
