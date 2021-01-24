    public class PermissionForm
    {
       public PermissionForm()
       {
           Permissions = new HashSet<PermissionEntity>();
       }
    
       public int Id {get; set;}
    
       public string Name {get; set;}
    
       public virtual ICollection<PermissionEntity> Permissions {get; set;}
    }
    public class PermissionEntity
    {
        public int PermissionFormId { get; set; }
    
        public PermissionItem PermissionItem { get; set; }
        public virtual PermissionForm PermissionForm { get; set; }
    }
    public enum PermissionItem : short
    {
       EDIT = 1,
       SHARE = 2,
       ADMIN = 3
    }
