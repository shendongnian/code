    public class HistoricalDataService : IHistoricalDataService
    {
        private DbContext dbContext;
        private DbContextTransaction dbContextTransaction;
    
        public HistoricalDataService(DbContext context)
        {
            this.dbContext = context;
        }
    
        void AddHistoricalData(HistoricalData hData)
        {
            if (dbContext.Database.CurrentTransaction == null)
            {
                dbContextTransaction = dbContext.Database.BeginTransaction();
            }
    
            // insert into HistoricalData table
            dbContext.SaveChanges();
        }
    
        void ProcessAllData()
        {
            // Here we process all records from HistoricalData table insert porcessing results into two other tables
        }
    
        void Rollback()
        {
            if (dbContextTransaction != null)
            {
                this.dbContextTransaction.Rollback();
            }
        }
    
        void SaveData()
        {
            this.dbContextTransaction.Commit();
            this.dbContextTransaction.Dispose();
        }
    }
