	// Some dummy data to play with
	var aras        = Enumerable.Range(0,  5).Select(i => new { Id = i, Name = "Ara" + i });
	var companies   = Enumerable.Range(0, 15).Select(i => new { Id = i, ARAId = i % 5, Activ = true, End = (DateTime?)null, Template = false });
	var wasteWaters = Enumerable.Range(0, 35).Select(i => new { Id = i, CompanyId = i / 15, End = (DateTime?)null });
	var allowances  = Enumerable.Range(0, 70).Select(i => new { Id = i, WasteWaterID = i, ParameterId = i % 4, Freight = i * 1000 });
	var parameters  = Enumerable.Range(0,  4).Select(i => new { Id = i, Name = "Parameter" + i });
