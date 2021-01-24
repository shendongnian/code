    var langMappings = new Dictionary<string, string>();
    // note that it's better to use two dictionaries - one for type names
    // and another for properties
    langMappings.Add("Afdeling", "Department");            
    langMappings.Add("TypeKode", "TypeCode");            
    langMappings.Add("Werkenemers", "Employees");            
    langMappings.Add("Persoon", "Person");
    // create reverse map
    foreach (var kv in langMappings.ToArray())
        langMappings.Add(kv.Value, kv.Key);
    var config = new MapperConfiguration(cfg => {
        // this will allow mapping type with name from dictionary key above
        // to another type indicated with name indicated by value
        // so, Afdeling to Department
        cfg.AddConditionalObjectMapper().Where((s, d) => langMappings.ContainsKey(s.Name) && langMappings[s.Name] == d.Name);
        cfg.AddMemberConfiguration()
        // this is default automapper configuration,
        // see http://docs.automapper.org/en/stable/Conventions.html
        .AddMember<NameSplitMember>()
        .AddName<PrePostfixName>(_ => _.AddStrings(p => p.Prefixes, "Get"))
        // and this one is our custom one
        .AddName<DictionaryMapper>(_ => _.Map = langMappings);
    });
    var mapper = config.CreateMapper();
    var result = mapper.Map<Afdeling, Department>(new Afdeling
    {
        Id = 1,
        TypeKode = "code",
        Werkenemers = new[] {
            new Persoon() {Id = 2}
        }
    });
