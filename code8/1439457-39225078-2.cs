    /* ------------------------ */
    
    var objectDictionnary = new Dictionary<string, object>();
    objectDictionnary.Add("Key1", "Contenuto");
    objectDictionnary.Add("Key2", 100);
    objectDictionnary.Add("Key3", complexArgument);
    
    
    byte[] serializedDicNewton = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject( objectDictionnary));
    var deserializeDictionnaryNewton = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(Encoding.UTF8.GetString(serializedDicNewton));
    
    deserializeDictionnaryNewton.ShouldDeepEqual(objectDictionnary); // works too
