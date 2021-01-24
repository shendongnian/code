    var query  = SearchMatches.Where(s => s.Description.ToLower().Contains(searchTerm.ToLower()));
            FindCollection collection = new FindCollection();
            foreach (var r in query )
            {
                collection.Add(r);
            }
