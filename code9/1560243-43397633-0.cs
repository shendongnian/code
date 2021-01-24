                var query = (from c in
                (from st in db.SalesTable 
                      join w in db.DateToWeek on st.DateBuy equals w.Date
                      group new {st, w} by new {w.WeekOfTheYear} into gr
                         select new 
                                   {
                                   Week = gr.Key.WeekOfTheYear,
                                   Buy = gr.Sum(x=>x.Buy),
                                   Sell = gr.Sum(x => x.Sell),
                                   InStock = gr.Sum(x=>x.Instock)
                                 })
                         group c by c.Week into gr2
                         select new
                         {
                             Date = gr2.Min(x=>x.Date),
                             Buy = gr2.Sum(x => x.Buy),
                             Sell = gr2.Sum(x => x.Sell),
                         }
                ).OrderBy(x => x.Date);
