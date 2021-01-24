    using (DbContextdb = new DbContext())
    {
            db.Configuration.ProxyCreationEnabled = false;
            IQueryable<Game> query=db.Game.Include(g=>g.Roles);
            if ( gameID.HasValue )
               query=query.Where(g=>g.ID==gameID.Value)
            if (roleID.HasValue)
               query=query.Where(g=>g.Roles.Any(r=>r.ID==roleID.Value))
            
            return query.ToList();
    }
