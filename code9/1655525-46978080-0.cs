    var query = from sr in loContext.StudentRequests
                join c in loContext.Classes on sr.ClassId equals c.ClassId
                join t in loContext.StudentRequestTimings on sr.RegistrationId equals t.RegistrationId
                select new { sr.RegistrationId, c.ClassId, sr.Name, c.ClassName, t.Color };
    
    var loOutput = query.ToList().GroupBy(item => new { item.RegistrationId, item.ClassId })
        .Select(group => new
        {
            Id = group.Key.RegistrationId,
            ClassId = group.Key.ClassId,
            ClassName = group.FirstOrDefault().ClassName,
            Name = group.FirstOrDefault().Name,
            Color = group.Select(item => item.Color).Aggregate((result, next) => result + "," + next)
        });
    
    foreach (var loItem in loOutput)
    {
        Console.WriteLine($"{loItem.Id}, {loItem.Name}, {loItem.Color}, {loItem.ClassName}");
    }
