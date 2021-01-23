    IEnumerable<Geo> geos = null;
    using(IEnumerator<string> enumerator = values.GetEnumerator())
    {
        string a;
        while(enumerator.MoveNext())
        {
            a = enumerator.Current;
            
            if (geos == null)
                geos = entities.Geos.Where(g => (g.ACode == Convert.ToInt16(a)));
            else
                geos = geos.Concat(entities.Geos.Where(g => (g.ACode == Convert.ToInt16(a))));
        }
    }
