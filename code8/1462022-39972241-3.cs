    var member = db.Members.Select(m=>
                new Member{
                    Name = m.FirstName + " " + m.LastName,
                    Title = m.Title,
                    ProjectId = m.ProjectId
                });
