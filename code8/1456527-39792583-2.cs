    var list = class1s.SelectMany(parent => parent.Class2s,
                                  (parent,child)=>
                                               new Result {
                                                  Class1Id = parent.Id,
                                                  Name = child.Name,
                                                  Value = child.Value
                                              }
               ).ToList();
