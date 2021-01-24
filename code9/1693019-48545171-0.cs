    var results = 
	    session
		    .Query<Abastecimento>()
   		    .Where(a => a.DtAbastecido <= dataFinal && a.DtAbastecido >= dataInicio)
		    .GroupBy(a => a.NumCarro.Id)
		    .Select(g => 
                new 
                {
                    NumCarroId = g.Key, 
                    Litri = g.Sum(a => a.Litro)
                })
		    .ToList();
