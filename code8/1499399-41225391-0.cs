    var minMax= doc.Descendants()
                   .Where(e=>e.Attribute("value")!=null)
                   .Aggregate(new {
                                    Min = int.MaxValue,
                                    Max = int.MinValue
                                  },
                              (seed, o) => new 
                                           {
                                             Min = Math.Min((int)o.Attribute("value"), seed.Min),
                                             Max = Math.Max((int)o.Attribute("value"), seed.Max)
                                           }
                             );
