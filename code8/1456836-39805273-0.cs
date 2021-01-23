	Mapper.Initialize(cfg => {
		cfg.CreateMap<Person, List<PersonCar>>()
			.ConstructProjectionUsing(
				p =>
					p.Cars.Select(c => new PersonCar { Name = p.Name, NumberPlate = c.NumberPlate })
					.ToList()
			);
	});
