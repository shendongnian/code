    var query = from p in context.Projects
                    select new DetailedProjectView
                    {
                        ProjectId=p.Id,
                        ProjectDetails= (from pd in context.ProjectDetails
                                        where  pd.Id == p.Id
                                        select new ProjectDetail 
                                        {
                                         DetailsId = pd.Id
                                         ProjectDetailName = pd.ProjectDetailName
                                        }
                    };
