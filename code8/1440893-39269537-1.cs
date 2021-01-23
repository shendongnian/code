    List<Task> joinedSPTasks = from a in spTasks
                        join b in projects on a.ProjectNumber equals b.Number
                        select new Task(){
                            ProjectNumber = a.Projectnumber,
                            Name = a.Name,
                            ProjectManager = b.ProjectManager,
                            Customer = b.Manager
                            };
