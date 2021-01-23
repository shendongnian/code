    public interface IFoo
    {
        Task<IBar> DoStuffAsync(string optionalArg, CancellationToken cancellationToken);
    }
    
    public static class IFooExtensions
    {
        public static IBar DoStuff(this IFoo foo, string optionalArg)
            => foo.DoStuffAsync(optionalArg, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
    }
