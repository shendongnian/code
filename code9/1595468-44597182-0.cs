    // Use an interface, so we don't have infrastructure dependencies in our domain
    public interface IScoped<T> where T : class
    {
        T Instance { get; }
    }
    // Register as singleton too.
    public sealed class Scoped<T> : IScoped<T> where T : class
    {
        private readonly IHttpContextAccessor contextAccessor;
        private HttpContext HttpContext { get; } => contextAccessor.HttpContext;
        public T Instance { get; } => HttpContext.RequestServices.GetService<T>();
        public Scoped(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
        }
    }
