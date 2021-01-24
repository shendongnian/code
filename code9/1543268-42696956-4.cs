    namespace Microsoft.AspNet.Identity.EntityFramework
    {
        //
        // Summary:
        //     Represents a Role entity
    	
        public class IdentityRole : IdentityRole<string, IdentityUserRole>
        {
            //
            // Summary:
            //     Constructor
            public IdentityRole();
            //
            // Summary:
            //     Constructor
            //
            // Parameters:
            //   roleName:
            public IdentityRole(string roleName);
        }	
    	
    public class IdentityRole<TKey, TUserRole> : IRole<TKey>
    where TUserRole : IdentityUserRole<TKey>
    {
        public TKey Id
        {
            get
            {
                return JustDecompileGenerated_get_Id();
            }
            set
            {
                JustDecompileGenerated_set_Id(value);
            }
        }
        public string Name
        {
            get;
            set;
        }
        public ICollection<TUserRole> Users
        {
            get
            {
                return JustDecompileGenerated_get_Users();
            }
            set
            {
                JustDecompileGenerated_set_Users(value);
            }
        }
        public IdentityRole()
        {
            this.Users = new List<TUserRole>();
        }
    }
    
    public class IdentityUserRole<TKey>
    {
        public virtual TKey RoleId
        {
            get;
            set;
        }
        public virtual TKey UserId
        {
            get;
            set;
        }
        public IdentityUserRole()
        {
        }
    }
    }
