    public async Task<List<Project>> GetProjectsFromSomeone(string someone) 
    {    
        var projects = from target in Context.Targets
                    join pt in Context.ProjectTargets on target.Id equals pt.TargetId
                    join prj in Context.Projects on pt.ProjectId equals prj.Id
                    where String.Equals(target.Someone, someone, StringComparison.InvariantCultureIgnoreCase)
                    select prj;
        return await projects.ToListAsync(); 
    }
