    var results = 
        db.Posts
          .Include(u => u.User)
          .GroupBy(g => g.User)
          .Select(g => new { Nick = g.Key.Name, Count = g.Count() })
          .OrderByDescending(e => e.Count)
          .ToList();
