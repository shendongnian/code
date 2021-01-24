    public interface IIncludable { }
    public interface IIncludable<out TEntity> : IIncludable { }
    public interface IIncludable<out TEntity, out TProperty> : IIncludable<TEntity> { }
    internal class Includable<TEntity> : IIncludable<TEntity> where TEntity : class
    {
        internal IQueryable<TEntity> Input { get; }
        internal Includable(IQueryable<TEntity> queryable)
        {
            // C# 7 syntax, just rewrite it "old style" if you do not have Visual Studio 2017
            Input = queryable ?? throw new ArgumentNullException(nameof(queryable));
        }
    }
    internal class Includable<TEntity, TProperty> :
        Includable<TEntity>, IIncludable<TEntity, TProperty>
        where TEntity : class
    {
        internal IIncludableQueryable<TEntity, TProperty> IncludableInput { get; }
        internal Includable(IIncludableQueryable<TEntity, TProperty> queryable) :
            base(queryable)
        {
            IncludableInput = queryable;
        }
    }
