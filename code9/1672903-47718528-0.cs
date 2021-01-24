    foreach(var d in data)
        {
           like if(Convert.ToString(d).All(char.IsDigit) && Convert.ToString(d).length <= Int32.MaxValue)
           {
              result.add(JsonConvert.DeserializeObject<A>(Convert.ToString(d)));
           }
           else
           {
              result.add(JsonConvert.DeserializeObject<B>(Convert.ToString(d)));
           }
                       
        }
