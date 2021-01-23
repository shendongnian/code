    var key = f.Key.ToLower();
    var value = f.Value.ToLower();
    var objects = repository.GetObjects().Where(t =>
        request.SearchFilters.All(f =>
            t.ObjectChild.Any(tt =>
                tt.MetaDataPairs.Any(md =>
                    md.Key.ToLower() == key && md.Value.ToLower().Contains(value)
                    )
                )
             )
        ).ToList();
