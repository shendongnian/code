            List<Task> joinedSPTasks = from a in spTasks
                    join b in projects on a.ProjectNumber equals b.Number
                    select new Task{
                        a.Projectnumber = a.Projectnumber,
                        a.Name = a.Name,
                        a.ProjectManager = b.ProjectManager,
                        a.Customer = b.Manager
                        };
