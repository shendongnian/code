    var GenericCastMethod = typeof(System.Linq.Enumerable)
      .GetMethod("Cast", BindingFlags.Public | BindingFlags.Static);
    var SpecificCastMethod = GenericCastMethod.MakeGenericMethod(FooType);
    var IEnumerableOfFoo = SpecificCastMethod.Invoke(null, new object[] { foos });
    var GenericToListMethod = typeof(System.Linq.Enumerable)
      .GetMethod("ToList", BindingFlags.Public | BindingFlags.Static);
    var SpecificToListMethod = GenericToListMethod .MakeGenericMethod(FooType);
    var ListOfFoo = SpecificToListMethod .Invoke(null, new object[] { FoosOfTypeFoo });
