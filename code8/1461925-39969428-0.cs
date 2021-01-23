    using (var db = new PlaceDBContext())
    {
        int count = 0;
        while(count < total)
        {
            var toCheck = db.Companies
                .AsNoTracking()
                .Include(x => x.CompaniesHouseRecords)
                .Where(x => x.CheckedCompaniesHouse == false)
                .OrderBy(x => x.ID)
                .Skip(count)
                .Take(1000)
                .ToList();
            foreach (var company in toCheck)
            {
                int tempID = company.ID   // Use whatever field is the id
                // do all the stuff that needs to be done
                // removed for brevity but it makes API calls
                // and creates/updates records
                var companyUpdate = db2.Companies.Where(c => c.ID == tempid).FirstOrDefault();    
                companyUpdate.CheckedCompaniesHouse = true;
                count++;
            }
            db2.SaveChanges();  
        }
    }
