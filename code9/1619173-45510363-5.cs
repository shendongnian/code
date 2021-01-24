    var query = from p in context.Projects
                    select new DetailedProjectView
                    {
                        ProjectId=p.Id,
                        ProjectDetails= (from pd in context.ProjectDetails
                                        where  pd.Id == p.Id
                                        select new DetailedProjectView 
                                        {
                                         ProjectId = pd.Id
                                         MainProjectDetails = select new ProjectDetails{ ProjectName = pd.ProjectDetailName}
                                        }
                    };
