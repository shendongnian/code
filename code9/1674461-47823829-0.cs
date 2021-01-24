    IEnumerable<Entities> entitiesToDisplay;
    if (Request.IsAuthenticated) {
        entitiesToDisplay = db.myEntities
         .where(x => x.RequiredRole == string.empty || User.IsInRole(x.RequiredRole);
    }
    else {
        entitiesToDisplay = new List();
    }
