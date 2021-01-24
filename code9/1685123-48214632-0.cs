    public class TextFileProcessor : IDataProcessor<TextFileConfiguration>
    {
         private readonly TextFileConfiguration configuration;
         
         public TextFileProcessor(TextFileConfiguration configuration) => this.configuration = configuration;
    
         public IEnumerable<TEntity> Read<TEntity>(configuration)
         {
             // Map, based on data from configuration and create object.
             // More...
         }
    }
