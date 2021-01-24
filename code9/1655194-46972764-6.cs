    static class MyDbContextExtensions
    {
        public static IQueryable<SpanishModel> SpanishModel(this MyDbContext dbContext)
        {
             return dbContext.Models.AsSpanishModels();
        }
    }
