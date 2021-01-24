    public PartialViewResult BranchSearch(String branchname, String country)
    {
        IQueryable<Branch> model = db.Branches;
        if (!string.IsNullOrEmpty(branchname))
        {
            model = model.Where(x => x.BranchName.Equals(branchname));
        }
        var result = model.ToList();
        return PartialView("BranchSearch", result);
    }
