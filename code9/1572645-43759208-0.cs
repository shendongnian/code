    private static readonly MethodInfo selectT = (from x in typeof(Queryable).GetMethods(BindingFlags.Public | BindingFlags.Static)
                                                    where x.Name == nameof(Queryable.Select) && x.IsGenericMethod
                                                    let gens = x.GetGenericArguments()
                                                    where gens.Length == 2
                                                    let pars = x.GetParameters()
                                                    where pars.Length == 2 &&
                                                        pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(gens[0]) &&
                                                        pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(gens))
                                                    select x).Single();
