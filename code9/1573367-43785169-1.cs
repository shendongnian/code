    [DbConfigurationType(typeof(EntityFrameworkConfiguration))] 
        public class EBS_GIROdbContext : DbContext
        {
    
            static EBS_GIROdbContext()
            {
                Database.SetInitializer<EBS_GIROdbContext>(null);
            }
