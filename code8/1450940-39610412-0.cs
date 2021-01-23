    var details  = _ctx.A
                       .Where (t=>t.Id ==something)
                       .Select(a => new {
                            Id = a.Id,
                            // ... other A properites , 
                            Bases = _ctx.Bases.OfType<Base1>().Select(m=> new {
                                Id = m.Id,
                                Name = m.Name,
                                SomeClass = m.SomeClass
                            });
                       }
