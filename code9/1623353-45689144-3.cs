    string id = groupObject1["id"].GetString();
    string title = groupObject1["nama"].GetString();
    for (int i = 1; i <= 6; i++)
    {
        if (groupObject1[$"img_{i}"] != null && groupObject1.ContainsKey($"img_{i}") && !String.IsNullOrEmpty(groupObject1[$"img_{i}"].GetString()))
        {
            listingDatasourceDetail.Add(new ListingClass
            {
                ID = id,
                Title = title,
                ImageURL = new BitmapImage(new Uri(groupObject1[$"img_{i}"].GetString()))
            });
        }
    }
