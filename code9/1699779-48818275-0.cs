     var results = from so in spObjects
                   orderby so.Date descending
                   select new {
                        Date = so.Date,
                        Items = (from so2 in spObjects
                                 where so2.Date == so.Date
                                 orderby so2.Priority
                                 select new {
                                      so2.Title,
                                      so2.Priority
                                 })
                        };
