    private static void Main(string[] args)
    {
        var regBuilder = new RegistrationBuilder();
        regBuilder.ForTypesMatching(t => typeof(IFoo).IsAssignableFrom(t))
            .Export<IFoo>();
        var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly(), regBuilder);
        foreach (var composablePartDefinition in catalog.Parts)
            if (typeof(IFoo).IsAssignableFrom(ReflectionModelServices.GetPartType(composablePartDefinition).Value))
                foreach (var importDefinition in composablePartDefinition.ImportDefinitions)
                    Console.WriteLine(
                        $"Contract name: {importDefinition.ContractName}. Is parameter (for ImportingConstructor stuff): {ReflectionModelServices.IsImportingParameter(importDefinition)}");
        Console.ReadLine();
    }
