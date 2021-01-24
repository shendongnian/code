	db
		.opt
		.Select(z => new
		{
			z.QuestionTitle,
			Count = z.Responces.Where(x => x.Responseval == Constants.options.Agree).Count()
        })
       	.Select(z => new
		{
          	z.QuestionTitle, 
          	z.Count,
          	Perc = (totresponcecount / z.Count) * 100
		})
        .ToList();
