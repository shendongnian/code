    public PartialViewResult BranchSearch(String branchname, String country)
    {
        IQueryable<Branch> model = db.Branches;
        if (!string.IsNullOrEmpty(branchname))
        {
            model = model.Where(x => x.BranchName.Equals(branchname
                                          ,StringComparison.OrdinalIgnoreCase));
        }
        // Now we are ready to query the db and get results. Call ToList()
        var result = model.ToList();
        return PartialView("BranchSearch", result);
    }
