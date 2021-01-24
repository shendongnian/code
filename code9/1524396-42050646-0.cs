    private void GetProjectReferences(StringBuilder sb, Project project)
    {            
        dynamic vsProject = project.Object;
        dynamic references = vsProject.References;
        sb.AppendLine(project.Name + ": " + references.Count);
        int counter = 1;
        foreach (dynamic reference in references)
        {
            sb.AppendLine((counter++)+": " + reference.Name + " (" + reference.Path +")");
        }
    }
