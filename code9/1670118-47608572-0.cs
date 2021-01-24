        public void SetEntityAsModifiedByProperties(DbContext yourDbContext, EntityClass incidentViolationForm, string properties)
        {
            var propertyList = properties.Split(',').ToList();
            foreach (var property in propertyList)
            {
                yourDbContext.Entry(incidentViolationForm).Property(property).IsModified = false;
            }
        }
