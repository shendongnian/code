    var userAudios = new List<Audio>();
    // Key userId
    // Value list of audiosIds
    var userAudiosRelations = new List<Relation>();
    foreach (var user in users)
    {
                        
        foreach (var audio in user.Audios)
        {
            if (!userAudios.Any(x => x.Id == audio.Id))
            {
                userAudios.Add(audio);
            }
            userAudiosRelations.Add(new Relation
            {
                User_Id = user.Id,
                Audio_Id = audio.Id
            });
        }
        user.Audios = null;
        db.Users.AddOrUpdate(user);
    }
    foreach (var audio in userAudios)
    {
        db.Audios.AddOrUpdate(audio);
    }
    db.SaveChanges();
    
    var existingRelations = db.Database.SqlQuery<Relation>("SELECT * FROM dbo.UserAudios").ToList();
    var relationsToAdd =
        userAudiosRelations.Where(
            x => existingRelations.All(y => x.User_Id != y.User_Id || x.Audio_Id != y.Audio_Id)).ToList();
    
    foreach (var relation in relationsToAdd)
    {
        db.Database.ExecuteSqlCommand("INSERT INTO dbo.UserAudios (User_Id, Audio_Id) VALUES (@p0, @p1)",
            relation.User_Id, relation.Audio_Id);
    }
