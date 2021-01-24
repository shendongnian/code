     var result = firstCollection.GroupJoin(secondCollection,
                s => s.Id,
                p => p.Sid,
                (first, second) =>
                {
                    dynamic foo;
                    if (someCondition)
                        foo = new { id = first.Id };
                    else
                        foo = new { 
                              id = first.Id, 
                              name = first.Name 
                        };
                    return foo;
                });
