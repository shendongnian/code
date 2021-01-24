    public class User
    {
        // Standard naming convention: automatic primary key
        public string ID { get; set; }
        // a user has many MAMRoles.
        // standard naming convention: automatic one-to-many with proper foreign key
        // declare the collection virtual!
        public virtual ICollection<MAMRole> MAMRoles { get; set; }
    }
    public class MAMRole
    {
        // standard naming cause automatic primary key
        public int ID { get; set; }
        
        // a MAMRole belongs to one user (will automatically create foreign key)
        // standard naming cause proper one-to-many with correct foreign key
        public string UserId {get; set;}
        public virtual User User {get; set;}
        // A MamRole has many MAMUserGroupModels
        // same one-to-many:
        // again: don't forget to declare the collection virtual
        public virtual ICollection<MAMUserGroupModel> MamUserGroupModels{ get; set; }
    }
    public class MAMUserGroupModel
    {
        // automatic primary  key
        public int ID {get; set;}
        // a MAMUserGroupModel belongs to one MAMUser
        // automatic foreign key
        public int MAMUserId {get; set;}
        public virtual MAMUser MAMUser {get; set;}
    }
