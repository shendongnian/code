    public class ExcelFileProcessor : IDataProcessor<ExcelFileConfiguration>
    {
        private readonly ExcelFileConfiguration configuration;
       
        public ExcelFileProcessor(ExcelFileConfiguration configuration) => this.configuration = configuration;
    
        public IEnumerable<TEntity> Read<TEntity>(configuration)
        {
             // Map based on data from configuration and create object.
             // More...
        }
    }
