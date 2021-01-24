    using (DbContextdb = new DbContext())
    {
            db.Configuration.ProxyCreationEnabled = false;
            IQueryable<Game> query=db.Game.Include(g=>g.Roles);
            if ( gameID > 0 )
               query=query.Where(g=>g.ID==gameID)
            if (roleID>0)
               query=query.Where(g=>g.Roles.Any(r=>r.ID==roleID))
            
            return query.ToList();
    }
