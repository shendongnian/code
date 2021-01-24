	var _queryResult = from s in patients
					   join k in illnesses on s.id equals k.id
					   select new
                       {
                           Name = s.name_surname, 
                           Id = k.id, 
                           Illness = k.illnessName 
                       };
	foreach (var item in _queryResult)
	{
		Console.WriteLine(item.Name + "-" + item.Id + "-" + item.Illness);
	}
