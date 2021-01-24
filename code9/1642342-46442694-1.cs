    context.Projects.Attach(project);
    context.Projects.Add(project);  
    context.Entry(project).State = EntityState.Modified;
    context.Entry(client).State = EntityState.Modified;
    context.SaveChanges();
