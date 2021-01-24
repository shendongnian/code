    //assuming using Newtonsoft
    
    var myJson = ....assuming one Country;
    var myJsonList = ...assuming List<Country>;
    
    var country = JsonConvert.DeserializeObject<Country>(myJson);
    var countries = JsonConvert.DeserializeObject<List<Country>>(myJson);
