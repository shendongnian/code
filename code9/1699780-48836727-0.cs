    var m = ((Func<Type, Type[]>)this.GetType().GetMethod("SumAvgFunc", BindingFlags.Static | BindingFlags.NonPublic)
                            .MakeGenericMethod(proptype).Invoke(null, null)).GetMethodInfo();
                        object obj = null;
                        if (!m.IsStatic)
                        {
                            obj = Activator.CreateInstance(m.DeclaringType);
                        }
                        return GetMethod(aggregate, m, 1, obj).MakeGenericMethod(type);
