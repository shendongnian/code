    class User
    {
      string Name { get; }
      Permissions Permissions { get; }
    }
    
    class Permissions
    {
      public User user {get;set;}
      public string UserName {get;set;}
      bool SomePermissionProperty { get;set; }
      IEnumerable<NestedPermission> NestedPermissions { get;set; }
    }
    
    class NestedPermission
    {
      public Permissions Permissions {get;set;}
      public string UserName {get;set;}
      bool SomeNestedProperty { get; }
    }
