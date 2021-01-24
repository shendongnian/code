	public async Task<ListResult<ProjectDTO>> GetListedProjects(int pageSize, int pageNumber, string status)
	{
		var projects = await unitOfWork.ProjectRepository.Get();
		//i cannot filter like this
		projects.Where(x => x.Status == (Status)Enum.Parse(typeof(Status), status));
		var orderedProjects = projects.OrderBy(x => x.Name);
		var projectList = orderedProjects.ToPagedList(pageNumber, pageSize);
		var data = projectList.Select(x => ToDTO.ProjectBuild(x)).ToList();
		return new ListResult<ProjectDTO> { Data = data, TotalCount = projectList.TotalItemCount };
	}
