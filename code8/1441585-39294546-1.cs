    IEnumerable<Geo> geos = null;
    foreach (string a in values)
    {
        string b = a;
        if (geos == null)
            geos = entities.Geos.Where(g => (g.ACode == Convert.ToInt16(b)));
        else
            geos = geos.Concat(entities.Geos.Where(g => (g.ACode == Convert.ToInt16(b))));
    }
