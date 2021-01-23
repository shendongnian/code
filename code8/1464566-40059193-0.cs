          autoMockContext
                .Mock<IPopulationReadRepository>()
                .SetupSequence(method => method.GetCityForNewClients(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult<Entities.Zonning.Population>(null))
                .Returns(Task.FromResult(new Entities.Zonning.Population { Id = 100, CityLongName = "Kharkiv, Kharkivska, Slobozhanshina" }));
