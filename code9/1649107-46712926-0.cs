    public class UserModel 
    {
        public List<UserAccessRight> AccessRights {get; set;}
    }
    public class UserAccessRight
    {
        public string Name {get; set;}
    }
    public static class SomeAuthHelperClass
    {
        public UserModel CurrentUser {get; set;}
        // some helper methods to retrieve data etc.
       public static CanDo(string accessRight)
       {
           return CurrentUser.AccessRights.Contains(ar => ar.Name.Equals(accessRight);
       }
    }
    .....
    
    btnEdit.Enabled = SomeAuthHelperClass.CanDo("EditSomething");
