    var q = from c in cq
            join sc in _context.TblStoryCharacter.AsNoTracking()
             on c.IdI equals sc.CharacterIdI
            join s in _context.TblStory.AsNoTracking().Include(s => s.TblStoryCharacter).ThenInclude(sc => sc.CharacterIdINavigation)
             on sc.StoryIdI equals s.IdI
            where s.TblStoryCharacter.All(sc => characters.Contains(sc.CharacterIdINavigation.NameVc))
            select s;
