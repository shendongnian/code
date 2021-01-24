       public class KpiContextFactory: IKpiContextFactory
        {
            private string _connection = @"Server=.\SQL2008EXP;Database=kpiDb;Trusted_Connection=True;";
    
            public KpiContext GetNewContext()
            {
                var optionsBuilder = new DbContextOptionsBuilder<KpiContext>();
                optionsBuilder.UseSqlServer(_connection);
    
                return new KpiContext(optionsBuilder.Options);
            }
        }
