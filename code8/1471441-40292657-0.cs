    public IActionResult Index(string searchString)
    {
        var query = from t in db.Jobs
                    select t;
        if (String.IsNullOrEmpty(searchString))
        {
            return View(query);
        }
        var words = searchString.Split(' ');
        var jobsMatching = query.Where(job => words.Any(job.Description.Contains)
                                           || words.Any(job.Title.Contains)
                                           || words.Any(job.Requirements.Contains));
        
        return View(jobsMatching);
    }
