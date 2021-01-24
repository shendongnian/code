    class Base { }
    class Base<T>: Base { }
    class Foo : Base<int> { }
    class Bar : Base<string> { }
    class Frob : Bar { }
    class FooBar: Base { };
    
    var genericTypeDefinition = typeof(Base<>).GetGenericTypeDefinition();
    var types = Assembly.GetExecutingAssembly()
                        .GetAllDescendantsOf(genericTypeDefinition)));
