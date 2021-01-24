    private static TEnum? GetEnum<TEnum>(string value) where TEnum : struct
    {
        TEnum result;
        return Enum.TryParse<TEnum>(value, out result) ? (TEnum?)result : null;
    }
    public async Task<ListResult<ProjectDTO>> GetListedProjects(int pageSize, int pageNumber, string status)
    {
        var projects = await unitOfWork.ProjectRepository.Get();
        //i cannot filter like this
        projects.Where(x => x.Status == GetEnum<Status>(status));
        var orderedProjects = projects.OrderBy(x => x.Name);
    
        var projectList = orderedProjects.ToPagedList(pageNumber, pageSize);
    
        var data = projectList.Select(x => ToDTO.ProjectBuild(x)).ToList();
        return new ListResult<ProjectDTO> { Data = data, TotalCount = projectList.TotalItemCount };
    }
