    private static string SelectGenreName(IEnumerable<Genre> all, Genre g)
    {
        var s = g.Name + '/';
        if(g.ParentId.HasValue){
            s += SelectGenreName(all, all.Single(x => x.Id == g.ParentId.Value));   
        }
        return s;
    }
