    Dictionary<string, string> NameDesc = new Dictionary<string, string>();
                NameDesc.Add("max", "desc1");
                NameDesc.Add("tim", "desc2");
    
                var description = NameDesc["max"];
                var maxExists = NameDesc.ContainsKey("max");
