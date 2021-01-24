    var input = @"
        public class TestClass1
        {
            public string TestID { get; set; }
            public string TestName { get; set; }
            public string OtherTest { get; set; }
            public int TestValue1 { get; set; }
            public TestClass1()
            {
            }
        }
        public class TestClass2
        {
            public string TestID { get; set; }
            public string TestName { get; set; }
            public int OtherTest { get; set; }
            public int TestValue2 { get; set; }
            public TestClass2()
            {
            }
        }";
    // parse input
    var tree = CSharpSyntaxTree.ParseText(input);
    // find class declarations and look up properties
    var classes = tree.GetCompilationUnitRoot().ChildNodes()
        .OfType<ClassDeclarationSyntax>()
        .Select(cls => (declaration: cls, properties: cls.ChildNodes().OfType<PropertyDeclarationSyntax>().ToDictionary(pd => pd.Identifier.ValueText)))
        .ToList();
    // find common property names
    var propertySets = classes.Select(x => new HashSet<string>(x.properties.Keys));
    var commonPropertyNames = propertySets.First();
    foreach (var propertySet in propertySets.Skip(1))
    {
        commonPropertyNames.IntersectWith(propertySet);
    }
    // verify that the property declarations are equivalent
    var commonProperties = commonPropertyNames
        .Select(name => (name, prop: classes[0].properties[name]))
        .Where(cp =>
        {
            foreach (var cls in classes)
            {
                // this is not really a good way since this just syntactically compares the values
                if (!cls.properties[cp.name].IsEquivalentTo(cp.prop))
                    return false;
            }
            return true;
        }).ToList();
    // start code generation
    var workspace = new AdhocWorkspace();
    var syntaxGenerator = SyntaxGenerator.GetGenerator(workspace, LanguageNames.CSharp);
    // create base class with common properties
    var baseClassDeclaration = syntaxGenerator.ClassDeclaration("BaseClass",
        accessibility: Accessibility.Public,
        modifiers: DeclarationModifiers.Abstract,
        members: commonProperties.Select(cp => cp.prop));
    var declarations = new List<SyntaxNode> { baseClassDeclaration };
    // adjust input class declarations
    commonPropertyNames = new HashSet<string>(commonProperties.Select(cp => cp.name));
    foreach (var cls in classes)
    {
        var propertiesToRemove = cls.properties.Where(prop => commonPropertyNames.Contains(prop.Key)).Select(prop => prop.Value);
        var declaration = cls.declaration.RemoveNodes(propertiesToRemove, SyntaxRemoveOptions.KeepNoTrivia);
        declarations.Add(syntaxGenerator.AddBaseType(declaration, syntaxGenerator.IdentifierName("BaseClass")));
    }
    // create output
    var compilationUnit = syntaxGenerator.CompilationUnit(declarations);
    using (var writer = new StringWriter())
    {
        compilationUnit.NormalizeWhitespace().WriteTo(writer);
        Console.WriteLine(writer.ToString());
    }
