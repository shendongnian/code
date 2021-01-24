    if (!string.IsNullOrEmpty(viewModel.TempCompany))
    {
       var f = new Company
       {
            CompanyName = viewModel.TempCompany
       };
       f.Referrals.Add(referral);
       _context.Companies.Add(f);//Entity graph gets added to context
       _context.SaveChanges(); //Savechanges will save both entities and asisgn the correct Id's for FK
    }
