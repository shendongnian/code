    public class Category : ICategory
    {
           private readonly IOptions<MyConfig> config;
    
           public Category(IOptions<MyConfig> config)
           {
                this.config = config;
           }
           public Categories Get(long id)
           {
                var value = config.Value.ApplicationName;
                var vars = config.Value.Version;
                return category;
          }
    }
