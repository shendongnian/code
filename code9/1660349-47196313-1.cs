       Dictionary<string, int> dictionary = ...
       int N = 2;
       int mod = dictionary.Count / N;
       Dictionary<string, int>[] result = dictionary
         .Select((pair, index) => new {
            index = index,
            pair = pair,  
          })      
         .GroupBy(item => item.index / mod > N - 1 ? N - 1 : item.index / mod) 
         .Select(chunk => chunk.ToDictionary(item => item.pair.Key, item => item.pair.Value)) 
         .ToArray();
        Dictionary<string, int> dict1 = result[0];
        Dictionary<string, int> dict2 = result[1]; 
          
