    public static class DbModelExtensions
    {
        public static Employee Find(this IQueryable<Employee> query, int id)
        {
            return query.Where(x => x.Id == id).FirstOrDefault();
        }
    }
