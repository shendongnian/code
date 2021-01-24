    using System.Data.Entity;
    class Program
    {
        static void Main(string[] args)
        {
            using (PatientContext pcontext = new DatabaseMigApp.PatientContext())
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<PatientContext, Configuration>());
                pcontext.Database.Initialize(true);
            }
        }
    }
