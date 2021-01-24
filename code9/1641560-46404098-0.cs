        var items = context.MyTable.Find(id)
                      .Select(x => new
                                   {
                                        P1 = table.Prop1,
                                        P2 = table.Prop2
                                   });
