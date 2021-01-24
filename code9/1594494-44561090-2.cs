    static void IndexSetter2(IList<ushort> indexVal, Rootobject objectVal) {
        int i = 0;
        foreach (var field in objectVal.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance)
                             .Where(c => c.Name.StartsWith("index") && c.FieldType == typeof(ushort))
                             .OrderBy(c => c.Name)) {
            field.SetValue(objectVal, indexVal[i]);
            i++;
        }
    }
