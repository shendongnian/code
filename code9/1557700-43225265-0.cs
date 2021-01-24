    var communityQuery = db.Communities.Include("CommunityUsers").AsQueriable();
      if (!String.IsNullOrEmpty(SearchQuery))
        {
            communityQuery = communityQuery.Where(s => s.CommunityName.Contains(SearchQuery)).AsQueriable();
        }
    var yourCustomObject = communityQuery.Select(elem => new CommunityWithUserCount()
    {
     Community = elem,
     Count = elem.CommunityUser.Count()
    }).ToList();
