    public static void RegisterConditionalInstance<TService>(
        this Container container, TService instance, Predicate<PredicateContext> predicate)
        where TService : class
    {
        container.RegisterConditional(typeof(TService),
            Lifestyle.Singleton.CreateRegistration(() => instance, container),
            predicate);
    }
