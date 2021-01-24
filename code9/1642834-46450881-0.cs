    namespace WhereTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var companies = new[] { new Company { Id = 1, Name = "abc" }, new Company { Id = 2, CompanyAddress1 = "abc" } };
                foreach (var company in FilterCompanies(companies, "abc", x => x.Name, x => x.CompanyCity))
                {
                    Console.WriteLine(company.Id);
                }
            }
    
            static List<Company> FilterCompanies(IEnumerable<Company> unfilteredList, string query, params Func<Company, string>[] properties)
            {
                return unfilteredList.Where(x => properties.Any(c => c.Invoke(x) == query)).ToList();
            }
        }
    
        public class Company
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string CompanyAddress1 { get; set; }
            public string CompanyPostCode { get; set; }
            public string CompanyCity { get; set; }
            public string CompanyCounty { get; set; }
        }
    }
