    public static class NinjectExtender
        {
            public const string Index = "INDEX";
    
            public static IBindingWithOrOnSyntax<TImplementation> Keyed<T, TImplementation, TKey>(this IKernel binding, TKey key) where TImplementation : T
                {
                    if (!binding.CanResolve<IIndex<TKey, T>>()) 
                    {
                        binding.Bind<IIndex<TKey, T>>().ToMethod(context => new Index<TKey,T>(context));
                    }
                    return binding.Bind<T>().To<TImplementation>().WithMetadata(Index, key);
                }
    
        }
    
        public class Index<T, M> : IIndex<T, M>
        {
            private readonly IContext context;
    
            public Index(IContext context)
            {
                this.context = context;
            }
    
            public bool TryGetValue(T key, out M value)
            {
                try
                {
                    value = this[key];
                    return true;
                }
                catch (KeyNotFoundException)
                {
                    value = default(M);
                    return false;
                }
            }
    
            public M this[T key]
            {
                get
                {
                    try
                    {
                        var service = context.Kernel.Get<M>(binding => binding.Get<T>(NinjectExtender.Index).Equals(key));
    
                        if (!service.Equals(default(M)))
                        {
                            return service;
                        }
                        else
                        {
                            throw new KeyNotFoundException();
                        }
                    }
                    catch (Exception)
                    {
                        throw new KeyNotFoundException();
                    }
                }
            }
        }
