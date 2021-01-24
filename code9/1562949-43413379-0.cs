            var posts =
            _db.Posts.Select(x => new { x.Id, x.Title, x.Slug, x.Image, x.IsActive,x.PostType,x.PostCategories })
                .Where(x => x.IsActive && x.Id != id && x.PostCategories.Intersect(_db.PostCategories.Where(y=>y.Posts.Any(p => p.Id==id))).Any())
                .OrderByDescending(x => x.Id).Take(20)
                .ToList();
