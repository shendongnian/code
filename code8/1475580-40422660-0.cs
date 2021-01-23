     Dictionary<string[], object[]> list = new Dictionary<string[], object[]>();
     var key = new string[] { "a", "a", "a" };
     list.Add(key, new object[] { });
     object[] values;   
     
     if(list.TryGetValue(key, out values))
     {
     }
