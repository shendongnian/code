    public class TestDecimalPropertyClassRepository
    {
        private readonly IList<TestDecimalPropertyClass> list;
        public TestDecimalPropertyClassRepository(IEnumerable<TestDecimalPropertyClass> repo)
        {
            list = repo.ToList();
        }
        public IEnumerable<TestDecimalPropertyClass> GetAll(Sorting sorting)
        {
            List<TestDecimalPropertyClass> entities = list
                .AsQueryable()
                .SortBy(sorting)
                .ToList();
            return entities;
        }
        public void Save(TestDecimalPropertyClass testDecimalPropertyClass)
        {
            list.Add(testDecimalPropertyClass);            
        }
    }
