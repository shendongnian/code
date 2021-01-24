    public interface ITransformationRule<in TSource, in TResult, in TContext> {}
    public class MyRule : ITransformationRule<object, object, object> {}
    
    public class RuleEngine<TContext, TSource, TResult>
    {
        public void Register<TRule>() // I would like to keep it just Register<TRule> but compiler would not let me
            where TRule : ITransformationRule<TSource, TResult, TContext>
        {
    
        }
    
    }
    var engine = new RuleEngine<object, object, object>();
    engine.Register<MyRule>();
