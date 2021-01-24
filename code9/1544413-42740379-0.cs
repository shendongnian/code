    void foo(String projectPath, IDictionary<String, String> globalProperties, String toolsVersion)
    {
        Project project = new Project(projectPath, globalProperties, toolsVersion);
        String baseIntermediateOutputPath = GetProjectProperty(project, "BaseIntermediateOutputPath");
        String intermediateOutputPath = GetProjectProperty(project, "IntermediateOutputPath");
        // ....
    }
    
    static String GetProjectProperty(Microsoft.Build.Evaluation.Project project, String propertyName)
    {
        return project.Properties
                      .FirstOrDefault(prop => String.Equals(prop.Name, propertyName, StringComparison.OrdinalIgnoreCase))
                     ?.EvaluatedValue;
    }
