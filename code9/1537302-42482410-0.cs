    public static IEnumerable<NonEqualProperty> Compare<T>(T first, T second) where T : class {
        var list = new List<NonEqualProperty>();
        var type = first.GetType();
        var properties = type.GetProperties();
        var basicTypes = properties.Where(p => !p.PropertyType.IsClass && !p.PropertyType.IsInterface
                                                || p.PropertyType == typeof(string));
        foreach (var prop in basicTypes) {
            var value1 = prop.GetValue(first, null);
            var value2 = prop.GetValue(second, null);
            if (object.Equals(value1, value2))
                continue;
            list.Add(new NonEqualProperty(prop.Name, value1, value2));
        }
        var enumerableTypes =
            from prop in properties
            where prop.PropertyType == typeof(IEnumerable) ||
                prop.PropertyType.GetInterfaces().Any(x => x == typeof(IEnumerable))
            select prop;
        foreach (var prop in enumerableTypes) {
            var value1 = (IEnumerable)prop.GetValue(first, null);
            var value2 = (IEnumerable)prop.GetValue(second, null);
            if (object.Equals(value1, value2))
                continue;
            if (value1 == null || value2 == null) {
                list.Add(new NonEqualProperty(prop.Name, value1, value2));
                continue;
            }
                
            IEnumerator enu1 = null, enu2 = null;
            try {
                try {
                    enu1 = value1.GetEnumerator();
                    enu2 = value2.GetEnumerator();
                    int ix = -1;
                    while (true) {
                        bool next1 = enu1.MoveNext();
                        bool next2 = enu2.MoveNext();
                        ix++;
                        if (!next1) {
                            while (next2) {
                                list.Add(new NonEqualProperty(prop.Name + "_" + ix, "MISSING", enu2.Current));
                                ix++;
                                next2 = enu2.MoveNext();
                            }
                            break;
                        }
                        if (!next2) {
                            while (next1) {
                                list.Add(new NonEqualProperty(prop.Name + "_" + ix, enu1.Current, "MISSING"));
                                ix++;
                                next1 = enu1.MoveNext();
                            }
                            break;
                        }
                        if (enu1.Current != null) {
                            var type1 = enu1.Current.GetType();
                            if ((type1.IsClass || type1.IsInterface) && type1 != typeof(string)) {
                                continue;
                            }
                        }
                        if (enu2.Current != null) {
                            var type2 = enu2.Current.GetType();
                            if ((type2.IsClass || type2.IsInterface) && type2 != typeof(string)) {
                                continue;
                            }
                        }
                        if (!object.Equals(enu1.Current, enu2.Current)) {
                            list.Add(new NonEqualProperty(prop.Name + "_" + ix, enu1.Current, enu2.Current));
                        }
                    }
                } finally {
                    var disp2 = enu2 as IDisposable;
                    if (disp2 != null) {
                        disp2.Dispose();
                    }
                }
            } finally {
                var disp1 = enu1 as IDisposable;
                if (disp1 != null) {
                    disp1.Dispose();
                }
            }
        }
        return list;
    }
