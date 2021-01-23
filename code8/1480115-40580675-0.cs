    var appPosotion = db.Positions.Any(o => o.Id== 5)) ?? new Position { Id = 5,   PositionName = "ABC" }
  
    Application appOne = new Application
    {
       Id = 8,
       ApplicationName = "AppOne",
       ApplicationPosotion = appPosotion  
    };
