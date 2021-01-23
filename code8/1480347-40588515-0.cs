    var answer = data.GroupBy(x => x.GroupID).Select(x => new { 
         ID = x.Min(y => y.ID),
         Name = x.Select(y => y.Name).ToList(),
         Type = x.Select(y => y.Type).ToList(),
         Location = x.Select(y => y.Location).ToList(),
         GroupId = x.Key
    }).ToList();
