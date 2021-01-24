    //Do this outside of your query, a method call can't be translated to sql
    var up= DateTime.Now.Date.AddDays(30);
    var down= DateTime.Now.Date.AddDays(-30);
    var query= dbContext.YogaSpaces
                        .Where(i => i.YogaProfile.ApplicationUserGuid == userId)
                        .SelectMany(i=>i.YogaSpaceEvents.Where(k => k.EventDateTime.Date > down && k.EventDateTime < up));
