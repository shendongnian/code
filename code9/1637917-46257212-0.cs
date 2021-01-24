    List<string> cityNames = new List<string>();
    GlobalWeatherReference.GlobalWeatherSoapClient client = new GlobalWeatherReference.GlobalWeatherSoapClient("GlobalWeatherSoap12");
    var allCountryCities = client.GetCitiesByCountry("Chad");
    if (allCountryCities.ToString() == "Data Not Found")
    {
       
    }
    DataSet ds = new DataSet();
    //Creating a stringReader object with Xml Data
    StringReader stringReader = new StringReader(allCountryCities);
    // Xml Data is read and stored in the DataSet object
    ds.ReadXml(stringReader);
    //Adding all city names to the List objects
    foreach (DataRow item in ds.Tables[0].Rows)
    {
        cityNames.Add(item["City"].ToString());
    }    
    cities_cb.DataSource = cityNames;
