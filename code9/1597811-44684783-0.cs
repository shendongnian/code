    var query = _dicDictionaryThread.Select(o => new {o.Key, Value = o.Value
        	                                                          .Where(y=>y.Value.Level > x)
                	                                                  .ToDictionary(y => y.Key, y => y.Value)})
                                    .Where(o => o.Value.Any())
                                    .ToDictionary(o => o.Key, o => o.Value);
