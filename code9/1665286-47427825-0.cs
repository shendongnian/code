    public partial class Entities : DbContext
    {
        public Entities():base(ConfigurationManager.ConnectionStrings["Entities"].ConnectionString)
        {
            
        }
    }
