    public class CachingContextConfiguration : DbConfiguration
    {
        public CachingContextConfiguration()
        {
            SetModelStore(new DefaultDbModelStore(Directory.GetCurrentDirectory()));
        }
        
    }
