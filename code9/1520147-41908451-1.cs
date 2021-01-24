    public IEnumerable<CategorySubjects> GetCountSubjectCategories()
    {
        try
        {
            return (from blog in db.BlogTables
                    group blog by blog.CatId
                    into catgy
                    select new CategorySubjects
                    {
                        Id = catgy.Key,
                        CountSubjects = catgy.Count()
                    };
                return countSubjectsList;
            }
            catch (Exception e)
            {
                Log.AddErrorLog(e, AdakLog.Service.DataBase, "1", false, false, true);
                return null;
            }
        }
    }
