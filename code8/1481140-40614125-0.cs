    interface ICompanyRepository 
    {
        IEnumerable<Company> GetCompanies();
    }
    class DummyCompanyRepository : ICompanyRepository 
    {
        private Dictionary<int, Company> _data;
        
        public DummyCompanyRepository()
        {
             //populate your dictionary
        }
        public IEnumerable<Company> GetCompanies() 
        {
             // return all dictionary.values;
        }
    }
