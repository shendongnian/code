    public partial class MainDbContext : DbContext
        {
    //....
      [DbFunction("CodeFirstDatabaseSchema", "IsAssignedIncludedInPickedRoles")]
        public static bool IsAssignedIncludedInPickedRoles(string pickedRoles, string assignedRoles)
        {
            throw new NotSupportedException();
        }
    
    //.....
    }
