    using (var dbContext = new YourEntityName())
                {
                    var result = (from mp in dbContext.ModelProperties
                                  join ps in dbContext.PropertySections on mp.SectionId equals ps.SectionId
                                  where ps.IsSpecSection = 1
                                  group a by new { propertyid } into g
                                  select sectionid , MAX(displayorder)AS DisplayOrder,propertyid AS PropertyId, 1 AS IsSpecSection).ToList(); 
