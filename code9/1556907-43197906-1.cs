    //Other code of calling service..
    string jsonText1 = await response1.Content.ReadAsStringAsync();
    var jsonObj = JObject.Parse(jsonText1);
    var data = jsonObj["data"].ToString();
          
    var listingDatasource = JsonConvert.DeserializeObject<List<ListingClass>>(data);
    itemGridView.ItemsSource = listingDatasource;
    busyIndicator.IsActive = false;
