    public class EntityFactory<TEntity, TDto> : IEntityFactory<TEntity, TDto> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper = new Mapper(new MapperConfiguration(v => { }));
        private DbSet<TEntity> _dbSet;
        private Type i = typeof(TEntity);
        private Expression<Func<IFoo, bool>> getFilterExpression(int userId)
        {
            return (x => x.Foos.Any(a => a.UserId == userId));
        }
        private class ReplaceVisitor : ExpressionVisitor
        {
            readonly Expression _originalExpression;
            readonly Expression _replacementExpression;
            public ReplaceVisitor(Expression originalExpression, Expression replacementExpression)
            {
                _originalExpression = originalExpression;
                _replacementExpression = replacementExpression;
            }
            public override Expression Visit(Expression node)
            {
                return _originalExpression == node ? _replacementExpression : base.Visit(node);
            }
            public static Expression VisitExpression(Expression node, Expression originalExpression, Expression replacementExpression)
            {
                return new ReplaceVisitor(originalExpression, replacementExpression).Visit(node);
            }
        }
        public List<TDto> Get()
        {
            IQueryable<TEntity> query = _dbSet;
            //If the object implements a special interface
            if (i.GetInterfaces().Contains(typeof(IFoo)))
            {
                var userId = 7;
                var baseFilterExpression = getFilterExpression(userId);
                var filterExpression = (Expression<Func<TEntity, bool>>)ReplaceVisitor.VisitExpression(
                    baseFilterExpression,
                    baseFilterExpression.Parameters.First(),
                    Expression.Parameter(typeof(TEntity)));
                //add the expression to the dbSet
                query = query.Where(filterExpression);
            }
            List<TEntity> d = query.AsNoTracking().ToList();
            return _mapper.Map<List<TDto>>(d);
        }
    }
    public interface IEntityFactory<TEntity, TDTO> { }
    public interface IFoo
    {
        List<FooItem> Foos { get; set; }
    }
    public class FooItem
    {
        public int UserId { get; set; }
    }
