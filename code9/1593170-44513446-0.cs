    namespace EF_Code_First_Tutorials
    {
        
        public class SchoolContext: DbContext 
        {
           public SchoolContext(): base()
           {
            
           }
            
           public DbSet<Student> Students { get; set; }
           public DbSet<Standard> Standards { get; set; }
        }
    }
