    var position = new Position { Id = 5};
    db.Positions.Attach(position);
                Application appOne = new Application
                {
                    Id = 8,
                    ApplicationName = "AppOne",
                    ApplicationPosotion = position
                };
    
                db.Applications.Add(appOne);
                db.SaveChanges();
