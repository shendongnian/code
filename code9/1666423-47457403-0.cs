    public class MyDbContext2 : MyDbContext
    {
        public override ObjectResult<Company> GetCompanies(string companyName)
        {
           Sanatize(companyname);
           return base.GetCompanies(companyName);
        }
    //. . .
    }
