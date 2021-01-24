    using (var theDb = new project_dbEntities())
    {
        IQueryable<TheEntityClass> query = theDbContext.TheEntityClass;
        if (!showInactive)
        {
            query = query.Where(x => x.active);
        }
        if (selectedYearId != years.ALL_YEARS)
        {
            var yearToFilter = years.GetById(selectedYearId);
            query = query.Where(x => x.first_effective_date >= yearToFilter.start &&
                                     x.first_effective_date <= yearToFilter.end);
        }
        var entities = query
            .Include(nameof(TheChildEntity))
            .OrderBy(x => x.name)
            .ToList();
        return View(new IndexViewModel(entities));
    }
