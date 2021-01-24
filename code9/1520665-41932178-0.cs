    var types =
        container.GetTypesToRegister(typeof(IAnimal), assemblies)
        .Concat(container.GetTypesToRegister(typeof(IDomesticAnimal), assemblies))
        .Distinct();
    container.RegisterCollection<IAnimal>(
        types.Where(typeof(IAnimal).IsAssignableFrom));
    container.RegisterCollection<IDomesticAnimal>(
        types.Where(typeof(IDomesticAnimal).IsAssignableFrom));
    container.Register<ICat, Cat>();
    container.Register<IDog, Dog>();
