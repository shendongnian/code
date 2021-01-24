            //Anonymous object in C#
            var any = new { UserName = "Adel@gmail.com", Password = "P@ssw0rd" };
            //Array of anonymous objects in C#
            object[] defaultUsers = {
                new {UserName = "Adel@gmail.com", Password = "P@ssw0rd" },
                new {UserName = "Mike@gmail.com", Password = "P@ssw0rd" },
                new {UserName = "John@gmail.com", Password = "P@ssw0rd" }
            };
            //Iterate through a list of anonymous objects in C#
            foreach (var user in defaultUsers)
            {
                var userName = user.GetType().GetProperty("UserName").GetValue(user);
                var password = user.GetType().GetProperty("Password").GetValue(user);
            }
