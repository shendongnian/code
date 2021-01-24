    public partial class MainDbContext : DbContext
        {
    //....
      [DbFunction("CodeFirstDatabaseSchema", "DateTimeToString")]
        public static bool IsAssignedIncludedInPickedRoles(string pickedRoles, string assignedRoles)
        {
            throw new NotSupportedException();
        }
    
    //.....
    }
