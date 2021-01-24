    var response = elasticClient.Search<dynamic>(
                            s => s.Query(q => q.QueryString(m => m.Query(elasticQueryModel.QueryString))
                                ).Source(src => src.Includes(f => f.Fields(fields))).Size(querySize).AllTypes().Index(elasticQueryModel.Index));
    var hits = response.Hits;
    var rows = new List<Dictionary<string, object>>();
    foreach (var hit in hits)
    {
         var row = new Dictionary<string, object>();
         foreach (var keyValuePair in hit.Source)
         {
                var pair = keyValuePair.ToString().Split(':');
                var key = pair[0].Replace("\"", "").Trim();
                var value = pair[1].Replace("\"", "").Trim();
                row[key] = value;
         }
         rows.Add(row);
     }
