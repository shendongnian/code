    dynamic data = JsonConvert.DeserializeObject(JsonInStringFormat);
    if (data.sucession == 0) //checking the dynamic object for this property
    {
        //here you already know "sites" has no values
        //do what you have to
    }
    else
    {
        //success!
        RootObject ro = JsonConvert.DeserializeObject<RootObject>(JsonInStringFormat);
        Sites test = ro.sites; //sites values retrieved!
    }
