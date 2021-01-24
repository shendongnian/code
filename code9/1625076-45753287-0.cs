    query = query.OrderBy(x => prop.GetValue(x, null));
    public int CountSpesific(string queryString, string namaKategori, string namaLaporan)
    {
        System.Reflection.PropertyInfo prop = typeof(YourType).GetProperty(namaKategori);
        var results = GetSearchResults(queryString); //will result in list
        var count = results.Where(o => o.KlasifikasiLaporan == namaLaporan 
                               && prop.GetValue(o) == true).Count();
        return count;
    }
