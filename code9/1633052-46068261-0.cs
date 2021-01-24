    JObject jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(json);
    foreach (var property in jsonObj.Properties())
    {
        if (property.Name.StartsWith("PL_DATA_HL"))
        {
            Console.WriteLine("Property: " + property.Name);
            JArray array = (JArray)property.Value;
            foreach (JObject values in array)
            {
                Console.WriteLine("Name: " + values.GetValue("name"));
                Console.WriteLine("Value: " + values.GetValue("value"));
            }
            Console.WriteLine("---------------------------------");
        }
    }
    Console.ReadKey();
