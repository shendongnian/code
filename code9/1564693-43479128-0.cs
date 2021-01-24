    public interface Transformer<TSource, TResult>
    {
        TResult Transform(TSource original);
    }
    public class NoopTransformer<TSource, TResult> : Transformer<TSource, TResult> where TResult : class
    {
        public TResult Transform(TSource original)
        {
            return original as TResult;
        }
    }
    public class Controller<TEntity, TResult> where TResult : class
    {
        private Transformer<TEntity, TResult> transformer;
        public Controller() : this(new NoopTransformer<TEntity, TResult>())
        { }
        public Controller(Transformer<TEntity, TResult> transformer)
        {
            this.transformer = transformer;
        }
    }
