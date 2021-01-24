    //Other code of calling service..
    string jsonText1 = await response1.Content.ReadAsStringAsync();
    var listingDatasource = JsonConvert.DeserializeObject<List<ListingClass>>(jsonText1);
    itemGridView.ItemsSource = listingDatasource;
    busyIndicator.IsActive = false;
