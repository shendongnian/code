    public IEnumerable<Expression<Func<TestEntity, Boolean>>> filters = new List<Expression<Func<TestEntity, Boolean>>>() { };
    public IQueryable<TestEntity> filter(IQueryable<TestEntity> input, IEnumerable<Expression<Func<TestEntity, Boolean>>> filters, int i) {
            if (i == 0)
                return input;
            return filter(input.Where(filters.ElementAt(i)), filters, i - 1);
    }
