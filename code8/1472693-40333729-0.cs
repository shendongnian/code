    var data = new[]
    {
        new
        {
            FirstName = "firstname",
            SurName = "surname",
            Id = "id",
            LogInTime = DateTime.Now.ToString(),
            LogOutTime = DateTime.Now.ToString()
        }
    };
    var items = data.SelectMany((x) => new[]
    {
        new
        {
            UserName = x.FirstName + " " + x.SurName,
            AccessDate = DateTime.Parse(x.LogInTime).ToShortDateString(),
            AccessTimeFrame = DateTime.Parse(x.LogInTime).TimeOfDay,
            Action = "Login",
            Comment = "Never delete this Archive"
        },
        new
        {
            UserName = x.FirstName + " " + x.SurName,
            AccessDate = DateTime.Parse(x.LogOutTime).ToShortDateString(),
            AccessTimeFrame = DateTime.Parse(x.LogOutTime).TimeOfDay,
            Action = "Logout",
            Comment = "Never delete this Archive"
        }
    })
    .Distinct()
    .OrderBy((x) => x.UserName);
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
