    dynamic jsonObj = JsonConvert.DeserializeObject(json);
    foreach (var set in jsonObj)
    {
        if(Convert.ToString(set.Name).Contains("PL_DATA_HL"))
            foreach (var sub in set.Value)
            {
                Console.WriteLine(sub.value);
            }
    }
