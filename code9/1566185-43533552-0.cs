    public class CompanyModel
        {
            public int CompanyID { get; set; }
            public string CompanyWebsite { get; set; }
            public string CompanyPresident { get; set; }
            public Employee Employee { get; set; }
        }
    
    var company = await _context.Companies
                    .Include(s => s.CompanyEmployee)
                        .ThenInclude(e => e.Employee)
                        .AsNoTracking()
                    .SingleOrDefaultAsync(m => m.CompanyID == id);
    
    //Bind data from company into CompanyModel
