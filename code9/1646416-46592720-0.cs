    private string BuildFullPath(Project project)
        {
            string path = string.Empty;
            while(project != null) {
               if(path != string.Empty)
                   path = "->" + path;
               path = project.Name + path
               project = project.ParentFolder;
            }
            return path;
        }
