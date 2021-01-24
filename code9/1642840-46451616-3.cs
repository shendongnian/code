    List<Company> FilterCompanies(List<Company> unfilteredList, string fieldToQueryOn, string query)
    {
       return unfilteredList
           .Where(x => x.GetType.GetProperty(fieldToQueryOn).GetValue(x)
           .ToString().ToLower().Contains(query.ToLower())).ToList();
    }
