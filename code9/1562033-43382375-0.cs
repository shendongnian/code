    public class ItemGroup 
    { 
        public string Name { get; set; } 
 
        public IList<GroupItem> Items { get; set; } 
    } 
 
    public class GroupItem 
    { 
        public int Id { get; set; } 
 
        public string Name { get; set; } 
    } 
