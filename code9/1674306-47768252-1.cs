            var intersectedItems = dic1.Where(x => dic2.ContainsKey(x.Key)).Select(x => new
            {
                Key = x.Key,
                Value = x.Value + " " + dic2[x.Key]
            }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            var dicUnion = dic1.Where(x => !intersectedItems.ContainsKey(x.Key))
                .Union(dic2.Where(x => !intersectedItems.ContainsKey(x.Key)))
                .Union(intersectedItems).OrderBy(k => k.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
