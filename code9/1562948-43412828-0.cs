    [ChildActionOnly]
    public PartialViewResult GetRelatedPost(int id)
    {
        var relatedposts =
            _db.Posts.Select(x => new { x.Id, x.Title, x.Slug, x.Image, x.IsActive,x.PostType,x.PostCategories })
                .Where(x => x.IsActive && x.Id != id && x.PostCategories.Select(y => y.Id).Intersect(_db.PostCategories.Select(y => y.Id)).Any())
                .OrderByDescending(x => x.Id).Take(20)
                .ToList();
    }).Any())
                .OrderByDescending(x => x.Id).Take(20)
                .ToList();
    }
