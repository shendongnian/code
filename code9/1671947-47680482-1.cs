                JArray arr = JArray.Parse(json);
    
                foreach (var el in arr.ToList())
                {
                  var obj = new JObject();
                  obj[el["id"].Value<string>()] = el["name"].Value<string>();
                  el.Replace(obj);
                }
    
                var res = arr.ToString();
