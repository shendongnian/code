	var recordsFac = xmlExeDoc.Descendants("pay").Select(x => new
	{
		
		cycle = x.Elements("data").Select(y => new
		{
			startDate = (y.Elements("startDate").Any() == true) ? (string)y.Element("startDate") : string.Empty,
			adjustedDueDate = (DateTime)y.Element("adjustedDueDate"),
			Rate = (decimal)y.Element("Rate"),
		}).Where(y => y.Rate > 0 && y.adjustedDueDate < DateTime.Now)
							   .Select
							   (
								   c => new
								   {
									   id = (string)x.Element("id"),
									   startDate = c.startDate,
									   adjustedDueDate = c.adjustedDueDate,
									   Rate = c.Rate,
									   log = x.Element("log")
								   }
							   ),
		
	}).ToList();
