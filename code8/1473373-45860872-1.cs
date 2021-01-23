    // .NET Core 1.0 + Platform Extensions
    // Microsoft.EntityFrameworkCore.Relational, Version=1.1.0.0, PublicKeyToken=adb9793829ddae60
    
    namespace Microsoft.EntityFrameworkCore
    {
        public static class RelationalDatabaseFacadeExtensions
        {
            public static IEnumerable<string> GetAppliedMigrations(this DatabaseFacade databaseFacade);
        }
    }
