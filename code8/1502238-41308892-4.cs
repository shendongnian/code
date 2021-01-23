    public class NavigationMenuModel {
       public UserType UserType { get; set; }
    }
    
    public enum UserType {
       Admin = 1,
       Enquiry = 2
    }
    public class MarksModel {
       public List<User> Users { get; set; }
       public NavigationMenuModel NavigationMenuModel { get; set; }
    }
