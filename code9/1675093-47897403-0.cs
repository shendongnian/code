     var result =  _dbContext.Set<SomeEntity>()
        .Select(c => new { c, Hello = _dbContext.Set<Entity>().Where(e => e.AnotherEntity.Any(x => x.Good && x.Bye == c.Id)).ToList() })
        .Select(ch => new SomeEntityDto
        {
            BlahBlah = ch.c.BlahBlah,
            Hello = ch.Hello,
            XXX = ch.c.XXX,
            YYY = ch.c.YYY
        });
