    var answer = (from c in db.customers 
                  join p in db.purchases 
                  on c.ID = p.CustomerID into subs
                  from sub in subs.DefaultIfEmpty()
                  group p by new { c.ID, c.Name } into gr
                  select new {
                      gr.Key.ID,
                      gr.Key.Name,
                      Total = gr.Count(x => x != null),
                      CountCompleted = gr.Count(x => x != null && x.CompletedTransaction)
                  }).ToList();
