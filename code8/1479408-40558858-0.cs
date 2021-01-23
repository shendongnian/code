    var type = typeof(Parent.Child);
    FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public |
    BindingFlags.Static | BindingFlags.FlattenHierarchy);
    var constants = fieldInfos.Where(f => f.IsLiteral && !f.IsInitOnly).ToList();
    var constValue = Console.ReadLine();
    var match = constants.FirstOrDefault(c => (string)c.GetRawConstantValue() == constValue);
