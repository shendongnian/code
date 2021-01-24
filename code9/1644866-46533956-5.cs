    public class PermissionForm
    {
       public int Id {get; set;}
    
       public string Name {get; set;}
    
       public PermissionItem Permissions {get; set;}
    }
    
    [Flags]
    public enum PermissionItem : short
    {
       EDIT = 1,
       SHARE = 2,
       ADMIN = 4 // note that each value must be a power of 2
    }
