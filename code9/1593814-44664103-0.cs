    int matchCount = 0;
    using (MappingDBUnitOfWork muw = new MappingDBUnitOfWork(new MappingEntities()))
                {
                    var BrandList = muw.BrandRepository.GetAll();
                    foreach (Brand brands in BrandList)
                    {
                        matchCount += dtCsv.Select("BRAND ='" + brands.BrandName + "'").Count();
                    }
                }
                
                if (matchCount != dtCsv.Rows.Count) return false;
