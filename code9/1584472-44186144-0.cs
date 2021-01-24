    foreach(var project in StudentList
      .Where(a=>IDsList.Contains(a.StudentID))
      .SelectMany(b=>b.Courses)
      .SelectMany(c=>c.Projects)
      .Where(p=>string.IsNullOrEmpty(p.ProjectName)))
    {
      project.ProjectName = "Dummy";
    }
  
