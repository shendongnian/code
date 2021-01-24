    var query = from g in empl.Teachers
                where g.Administrator.username=="cs"
                select new {
                    Teacher_Id = g.Id,
                    Teacher_Name = g.username,
                    Administrator_Id = g.Id,
                    Administrator_Name = g.Administrator.username,
                    //etc...
                };
