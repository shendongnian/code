    private static readonly MethodInfo anyT = (from x in typeof(Enumerable).GetMethods(BindingFlags.Public | BindingFlags.Static)
                                                where x.Name == nameof(Enumerable.Any) && x.IsGenericMethod
                                                let gens = x.GetGenericArguments()
                                                where gens.Length == 1
                                                let pars = x.GetParameters()
                                                where pars.Length == 2 &&
                                                    pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(gens[0]) &&
                                                    pars[1].ParameterType == typeof(Func<,>).MakeGenericType(gens[0], typeof(bool))
                                                select x).Single();
