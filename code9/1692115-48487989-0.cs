    var myprop2Items = new List<JObject>();
    
    foreach(var value in myObject) {
                                myprop2Items.Add(new JObject(
                                    new JProperty(value.Name, value.Value)
                                ));
        
    } 
    
    
    JObject grid =
                new JObject(
                new JProperty("myprop", "value 1"),
                new JProperty("name", 
                    new JArray(
                                    new JObject(
                            new JProperty("myprop2", "value 2"),
                            myprop2Items
                            )
                        )
                    )
                )
            )
