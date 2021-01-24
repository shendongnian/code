            if (Company != null || City != null)
            {
                if (!string.IsNullOrEmpty(Company))
                {
                    customers1 = (!string.IsNullOrEmpty(City)) ?
                        customers1.Where(s => s.CompanyName.Contains(Company) && s.City.Contains(City))
                        : customers1.Where(s => s.CompanyName.Contains(Company));
                }
                if (!string.IsNullOrEmpty(City))
                {
                    customers1 = (!string.IsNullOrEmpty(Company)) ?
                        customers1.Where(s => s.CompanyName.Contains(Company) && s.City.Contains(City))
                        : customers1.Where(s => s.City.Contains(City));
                }
                return customers1.ToList();
            }
