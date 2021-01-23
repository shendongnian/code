    // LInqKit requires expressions to be put into variables
    var projects = Linq.Expr((Company c) => c.Projects);
    var projectFilter = Project.IsVisibleForResearcher(userId);
    var companies = db.Companies.AsExpandable()
    	.Where(c => projects.Invoke(c).Any(p => projectFilter.Invoke(p)))
    	.Select(c => new CompanyListDto
    	{
    		Id = c.Id,
    		Name = c.Name,
    		LogoId = c.LogoId,
    		ProjectCount = projects.Invoke(c).Count(p => projectFilter.Invoke(p))
    	});
