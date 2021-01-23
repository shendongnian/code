    IEnumerable<Geo> geos = null;
    using(IEnumerator<string> enumerator = values.GetEnumerator())
    {
        while(enumerator.MoveNext())
        {
            string a = enumerator.Current;
            
            if (geos == null)
                geos = entities.Geos.Where(g => (g.ACode == Convert.ToInt16(a)));
            else
                geos = geos.Concat(entities.Geos.Where(g => (g.ACode == Convert.ToInt16(a))));
        }
    }
