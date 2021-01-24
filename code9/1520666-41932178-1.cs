    var types =
        container.GetTypesToRegister<IAnimal>(assemblies)
        .Concat(container.GetTypesToRegister<IDomesticAnimal>(assemblies))
        .Distinct();
    container.Collection.Register<IAnimal>(
        types.Where(typeof(IAnimal).IsAssignableFrom));
    container.Collection.Register<IDomesticAnimal>(
        types.Where(typeof(IDomesticAnimal).IsAssignableFrom));
    container.Register<ICat, Cat>();
    container.Register<IDog, Dog>();
