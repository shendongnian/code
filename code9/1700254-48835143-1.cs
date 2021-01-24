    public List<KeyValuePair<string, string>> CombineWithPriority(params List<KeyValuePair<string, string>>[] allLists)
     {
         var results = new Dictionary<string, string>();
     
         foreach (var list in allLists)
         {
             foreach (var kvp in list)
             {
                 if (!results.ContainsKey(kvp.Key))
                 {
                     results.Add(kvp.Key, kvp.Value);
                 }
             }
         }
     
         return results
             .OrderBy(kvp => kvp.Key)
             .ToList();
     }
