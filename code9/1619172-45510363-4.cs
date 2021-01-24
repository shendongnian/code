    public class DetailedProjectView
    {
        public int ProjectId {get;set;}
        public IEnumerable<Project> MainProjects {get;set;} // Not Required
        public IEnumerable<ProjectDetails> MainProjectDetails {get;set;}
    }
