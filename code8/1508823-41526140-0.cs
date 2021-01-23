    abstract class Orderer {
        public abstract IQueryable<Goal> Order(IQueryable<Goal> queryable);
    }
    class Orderer<T> : Orderer {
        private readonly Expression<Func<Goal, T>> _property;
        public Orderer(Expression<Func<Goal, T>> property) {
            _property = property;
        }
        public override IQueryable<Goal> Order(IQueryable<Goal> queryable) {
            return queryable.OrderBy(_property);
        }
        public override IQueryable<Goal> OrderDescending(IQueryable<Goal> queryable) {
            return queryable.OrderByDescending(_property);
        }
    }
    Orderer makeOrderer<T>(Expression<Func<Goal, T>> property) {
        return new Orderer(property);
    }
