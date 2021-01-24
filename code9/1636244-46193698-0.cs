    return DbContext.Projects.Include(t => t.Tasks).Select(p => new ProjectDto
        {
            Id = p.Id,
            Name = p.Name,
            Tasks = p.Tasks.Select(t => new TaskDto()
            {
                Id = t.Id,
                Name = t.Name,
                ProjectId = t.ProjectId,
                Task = t,
                KeyId = t.KeyId
            }).ToList()
        });
