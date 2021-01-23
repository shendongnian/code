                List<MyType> myResults;
                using (Entities context = new Entities())
                {
                    var results = (from rc in context.RC
                        join r in context.R on rc.RId equals r.Id
                        join c in context.C on rc.CId equals c.Id
                        select rc).ToList();
    
                    myResults = results.Select(rc => new MyType
                    {
                        Id = rc.Id,
                        Rule = new IdName
                        {
                            Id = rc.R.Id,
                            Name = rc.R.Name
                        },
                        Conjuction = new IdName
                        {
                            Id = rc.C.Id,
                            Name = rc.C.Conjuncation
                        },
                        Field = new IdName
                        {
                            Id = rc.F!= null ? rc.F.Id : 0,
                            Name = rc.F!= null ? rc.F.Name : null
                        },
                        Expression = new IdName
                        {
                            Id = rc.E!= null ? rc.E.Id : 0,
                            Name = rc.E!= null ? rc.E.Expression : null
                        },
                        DisplayOrder = rc.Order,
                        Value1 = rc.Value,
                        Value2 = rc.Value2
                    }).ToList();
                }
