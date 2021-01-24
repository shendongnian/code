    public void SomeService()
    {
        var myData = Repository.Get(x => x.CountryId > 0, x => new { x.CountryId, x.Name });
        foreach (var item in myData)
        {
            var id = item.CountryId;
            var name = item.Name;
            // ... 
        }
    }
