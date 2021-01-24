    /// <summary>
    /// Implements a recursive function that takes a single parameter
    /// </summary>
    /// <typeparam name="T">The Type of the Func parameter</typeparam>
    /// <typeparam name="TResult">The Type of the value returned by the recursive function</typeparam>
    /// <param name="f">The function that returns the recursive Func to execute</param>
    /// <returns>The recursive Func with the given code</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Func<T, TResult> Y<T, TResult>(Func<Func<T, TResult>, Func<T, TResult>> f)
    {
        Func<T, TResult> g = null;
        g = f(a => g(a));
        return g;
    }
