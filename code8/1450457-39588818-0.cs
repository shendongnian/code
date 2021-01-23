       var x = context.T1.Where(t => t.Id == context.T2.InstanceId)
               .Select(x => new {
                  t,
                  t.Instance //use the related entity here)
                }).ToList();
