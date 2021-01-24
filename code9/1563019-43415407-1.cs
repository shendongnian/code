        var channels = db.Channels.AsQueryable();
        #region filtering
          if (id!=0)
            channels = channels.Where(x=>x.CategoryId == id);
          if (word!="0")
            channels = channels.Where(x=>x.Title.Contains(word) || x.Desc.Contains(word));
        #endregion filtering
        #region server-side ordering
          channels = channels.OrderBy(x=>x.id);
        #endregion server-side ordering
        #region client-side ordering
          var seed = randomstring.GetHashCode();
          var random = new Random(seed);
          var channelList = channels.AsEnumerable(); // force client side
          var maxid = channelList.Select(x=>id).Max();
          var keys = Enumerable
            .Range(0,maxid)
            .ToDictionary(x=>x,x=>random.Next());
          var sorted = channelList
            .OrderBy(x=>keys[x.id]);
        #endregion client-side ordering
        #region paging
          var results = sorted
            .Skip(skip)
            .Take(pageSize)
            .ToList();
        #endregion paging
