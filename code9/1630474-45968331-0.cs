    string projectTitle;
    var result = context.vw_Projects
        .Where(p => p.ProjectID == projID)
        .Take(1)
        .Select(p => new { p.ProjectTitle })
        .FirstOrDefault();
    
    if (result != null)
    {
        projectTitle = result.ProjectTitle;
    }
    else
    {
        throw new Exception("Invalid Project ID");
    }
