	from st in db.SalesTable 
	join w in db.DateToWeek on st.DateBuy equals w.Date
	group new {st, w} by new {w.Date, w.WeekOfTheYear} into gr
	select new 
	{
		Date = gr.Key.Date,
		Week = gr.Key.WeekOfTheYear,
		Buy = gr.Sum(x=>x.Buy),
		Sell = gr.Sum(x => x.Sell),
		InStock = gr.Sum(x=>x.Instock)
	}
