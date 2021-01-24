        public async Task AddApplicationAsync(ApplicationDriverDomain model)
        {
            Infrastructure.Asset.ApplicationDriver driver = mapper.Map<Infrastructure.Asset.ApplicationDriver>(model);
            var cdlTypes = driver.CommercialLicense.CDLTypes;
            foreach (var type in cdlTypes)
            {
                db.ApplicationLicenseCDLTypes.Attach(type);
            }
            var endorsements = driver.CommercialLicense.Endorsements;
            foreach (var endorsement in endorsements)
            {
                db.ApplicationLicenseEndorsements.Attach(endorsement);
            }
            db.ApplicationDrivers.Add(driver);
            await db.SaveChangesAsync();
        }
