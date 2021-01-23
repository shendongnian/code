        private static async void AddCountries(ApplicationDbContext db)
        {   
            if (db.Country.Any())
            {
                return;   // DB has been seeded
            }
            db.AddRange(
                new Country { Name = "England", Code = "En" },
                new Country { Name = "France", Code = "Fr" }
                );
           db.SaveChanges();
       }
