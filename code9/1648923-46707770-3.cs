    static readonly IDictionary<Type,Func<object,object[]>> GetItems = new Dictonary<Type,Func<object,object[]>> {
        [typeof(ValueTuple<>)] = o => new object[] {((dynamic)o).Item1}
    ,   [typeof(ValueTuple<,>)] = o => new object[] {((dynamic)o).Item1, ((dynamic)o).Item2}
    ,   [typeof(ValueTuple<,,>)] = o => new object[] {((dynamic)o).Item1, ((dynamic)o).Item2, ((dynamic)o).Item3}
    ,   ...
    };
