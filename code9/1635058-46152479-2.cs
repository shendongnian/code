    public class ViewModel
    {
       public Company MyCompany { get; set;}
       public CompanyBranches MyCompanyBranches { get; set;}
       //If you have multiple items, you can do this:
       public IList<CompanyBranches> LstCompanyBranches { get; set;}
    }
