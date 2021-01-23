    public class BuildType
    {
        public string DisplayName { get; set; }
    }
    
    public class Type
    {
        public string DisplayName { get; set; }
    }
    
    public class RootObject
    {
        public int ReferenceId { get; set; }
        public int MasterId { get; set; }
        public BuildType BuildType { get; set; }
        public Type Type { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }
