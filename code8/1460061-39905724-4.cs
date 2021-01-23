    public interface IRetryCondition<TResult>
    {
         TResult Until(Func<TResult, bool> condition);
    }
  
    public class RetryCondition<TResult> : IRetryCondition<TResult>
    {
         private TResult _value;
         private Func<IRetryCondition<TResult>> _retry;
         public RetryCondition(TResult value, Func<IRetryCondition<TResult>> retry)
         {
             _value = value;
             _retry = retry;
         }
         public TResult Until(Func<TResult, bool> condition)
         {
             return condition(_value) ? _value : _retry().Until(condition);
         }
    }
