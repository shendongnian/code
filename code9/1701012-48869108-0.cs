    public static void ToCacheOrNotToCache()
    {
        var typeofA = typeof(A);
        var typeofB = typeof(B);
        var getTypeA = new A().GetType();
        var getTypeA2 = new A().GetType();
        var getTypeB = new B().GetType();
        var baseTypeB = getTypeB.BaseType;
        Console.WriteLine(
            $"typeof A ref equals getTypeA: {ReferenceEquals(typeofA, getTypeA)}");
        Console.WriteLine(
            $"typeof B ref equals getTypeB: {ReferenceEquals(typeofB, getTypeB)}");
        Console.WriteLine(
            $"typeof A ref equals baseTypeB: {ReferenceEquals(typeofA, baseTypeB)}");
        Console.WriteLine(
            $"getTypeA ref equals getTypeA2: {ReferenceEquals(getTypeA, getTypeA2)}");
    }
    class A { }
    class B: A { }
