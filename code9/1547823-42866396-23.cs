    public class ToolTypeModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            return (obj is ToolTypeModel)
                        ? (obj as ToolTypeModel).Id == Id
                        : false;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
