    var pci = new ProjectCreationInformation
                {
                    Name = "new1",
                    Description = "test",
                    EnterpriseProjectTypeId = new Guid(""),
                    //Id = Guid.NewGuid(),
                    Start = DateTime.UtcNow,
                    TaskList = taskList
                };
                var project = context.Projects.Add(pci);
 
