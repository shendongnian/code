      Type underlyingType = typeToResolve.GetGenericArguments().First();
                    if (m_TypeToConcrete.ContainsKey(underlyingType))
                    {
                        MethodInfo castMethod = typeof(Enumerable).GetMethod(nameof(Enumerable.Cast));
                        IEnumerable<object> instances = m_TypeToConcrete[underlyingType].GetEnumerable();
    
                        return (T)castMethod.MakeGenericMethod(underlyingType).Invoke(instances, new object[] { instances });
                    }
