    public IEnumerable<T> CommonItems<T>(IEnumerable<IEnumerable<T>> collections)
    {
        if(collections == null)
            throw new ArgumentNullException(nameof(collections));
        using(var enumerator = collections.GetEnumerator())
        {
			if(!enumerator.MoveNext())
				return Enumerable<T>.Empty();
			var overall = new HashSet<T>(enumerator.Current);
			while(enumerator.MoveNext())
			{
				var common = new HashSet<T>();
				foreach(var item in enumerator.Current)
				{
					if(hash.Contains(item))
						common.Add(item);
				}
				overall = common;
				if(overall.Count == 0)
					break;
			}
			return overall;
        }
    }
