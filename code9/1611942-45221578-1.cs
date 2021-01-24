    using System.Linq.Expressions;
    public class LimitWatcher
    {
        public LimitWatcher(Limiter lim, string propName)
        {
            myLimiter = lim;
            limitName = propName;
            var parameter = Expression.Parameter(typeof(Limiter), "x");
            var member = Expression.Property(parameter, propName);
            var finalExpression = Expression.Lambda<Func<Limiter, int>>(member, parameter);
            getter = finalExpression.Compile();
        }
        private Func<Limiter, int> getter;
        private Limiter myLimiter { get; }
        public string limitName { get; set; }
        public int FooLimit { get { return getter(myLimiter); } }
    }
