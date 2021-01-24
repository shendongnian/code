      public class IdentityRoleView
        {
            public IdentityRoleView()
            {
                Users = new List<IdentityUser>();
            }
            public virtual string Id { get; set; }
            public virtual string Name { get; set; }
            public virtual IList<IdentityUser> Users { get; set; }
        }
