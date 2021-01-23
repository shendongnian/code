    public class DBInitializer : DropCreateDatabaseAlways<FravaerContext>
    {
        protected override void Seed(FravaerContext context)
        {
            //create the users first
            //save the users in a list so later we can create the departments
            var users = new List<User>();
    
            for (var i = 1; i <= 4; i++)
            {
                var user = new User
                {
                    Id = i,
                    Absences = new List<Absence>(),
                    Email = $"chief{i}@chief.dk",
                    FirstName = $"Chief{i}",
                    LastName = $"Chiefsen{i}",
                    Password = "admin",
                    UserName = "user" + i,
                    Role = Role.DepartmentChief
                };
                users.Add(user);
                context.Users.Add(user);
            }
    
            //create one department for each user (with that user as the chief)
            var departmentId = 1;
    
            //save the departments so later we can seed them with users
            var departments = new List<Department>();
            foreach (var user in users)
            {
                var d = new Department
                {
                    Id = departmentId++,
                    DepartmentChief = user
                };
    
                departments.Add(d);
                context.Departments.Add(d);
            }
    
            //seeed the departments with users
            foreach (var department in departments)
            {
                //add 5 users to each department
                for (var i = 1; i < 5; i++)
                {
                    var user = new User
                    {
                        Absences = new List<Absence>(),
                        Email = $"user{department.Id}{i}@user.dk",
                        FirstName = $"User{department.Id}{i}",
                        LastName = $"Username{department.Id}{i}",
                        Password = "user",
                        UserName = "" + department.Id + i,
                        Role = Role.DepartmentChief
                    };
                    department.Users.Add(user);
                }
            }
        }
    }
