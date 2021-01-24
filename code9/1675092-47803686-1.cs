    var result =  _dbContext.Set<SomeEntity>().AsExpandable().Select(c => new SomeEntityDto
        {
            BlahBlah = c.BlahBlah,
            Hello = _dbContext.Set<Entity>().Where(IsNicePredicate(c.Id)).ToList(),
            XXX = c.XXX,
            YYY = c.YYY
        });
