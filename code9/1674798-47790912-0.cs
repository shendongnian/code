    public sealed class AutofacQueryFactory : IQueryFactory
    {
        private readonly ILifetimeScope scope;
        public AutofacQueryFactory(ILifetimeScope scope)
        {
            this.scope = scope;
        }
        /// <see cref="IQueryFactory" />
        public IQueryHandler<TQuery, TResult> BuildHandler<TQuery, TResult>() where TQuery : IQuery<TResult>
        {
            return this.scope.Resolve<IQueryHandler<TQuery, TResult>>();
        }
    }
