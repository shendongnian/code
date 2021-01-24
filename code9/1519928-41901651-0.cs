        public bool InsertPerson(PersonDto personToInsert)
        {
            try
            {
                using (var db = new PartnerDBContext())
                {
                    var companies = personToInsert.OwnedCompanies;
                    personToInsert.OwnedCompanies = new List<CompanyDto>();
                    foreach (var company in companies)
                    {
                        var companyInDb = db.Companies.Find(company.PartnerId);
                        personToInsert.OwnedCompanies.Add(companyInDb);
                    }
                    db.Persons.Add(personToInsert);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
