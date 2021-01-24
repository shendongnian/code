    /// <summary>
    /// Get individual handlers of the invocation list of the specified <paramref name="@event"/>,
    /// ordered by the <see cref="InvocationOrderAttribute"/> of the handler's method.
    /// </summary>
    /// <typeparam name="TDelegate">Delegate type of the <paramref name="@event"/>.</typeparam>
    /// <exception cref="ArgumentException"><typeparamref name="TDelegate"/> is not a delegate type.</exception>
    /// <remarks>Handlers without the attribute come last.</remarks>
    public static IEnumerable<TDelegate> OrderedInvocationList<TDelegate>(TDelegate @event)
    {
        if (!typeof(Delegate).IsAssignableFrom(typeof(TDelegate)))
            throw new ArgumentException(typeof(TDelegate) + " is not a delegate type.");
        if (@event == null) // empty invocation list
            return Enumerable.Empty<TDelegate>();
        return ((Delegate)(object)@event).GetInvocationList()
            .Select(handler =>
            {
                var attribute = (InvocationOrderAttribute)handler.Method.GetCustomAttributes(typeof(InvocationOrderAttribute), false).FirstOrDefault();
                return new
                {
                    Handler = (TDelegate)(object)handler,
                    Order = attribute != null ? attribute.Order : int.MaxValue
                };
            })
            .OrderBy(ho => ho.Order)
            .Select(ho => ho.Handler);
    }
