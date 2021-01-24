    public interface IIncludable { }
    public interface IIncludable<out TEntity> : IIncludable { }
    public interface IIncludable<out TEntity, out TProperty> : IIncludable<TEntity> { }
    internal class IncludeProvider<TEntity> : IIncludable<TEntity> where TEntity : class
    {
        internal IQueryable<TEntity> Input { get; }
        internal IncludeProvider(IQueryable<TEntity> queryable)
        {
            // C# 7 syntax, rewrite it "old style" if you do not have Visual Studio 2017
            Input = queryable ?? throw new ArgumentNullException(nameof(queryable));
        }
    }
    internal class Includable<TEntity, TProperty> :
        IncludeProvider<TEntity>, IIncludable<TEntity, TProperty>
        where TEntity : class
    {
        internal IIncludableQueryable<TEntity, TProperty> IncludableInput { get; }
        internal Includable(IIncludableQueryable<TEntity, TProperty> queryable) :
            base(queryable)
        {
            IncludableInput = queryable;
        }
    }
