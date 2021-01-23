    public class DataAccessLayer : IAspect
    {
        public IEnumerable<IAdvice> Advise(MethodInfo method)
        {
            //define how to rewrite method
            yield return Advice<T>.Basic.Arround(invoke =>
            {
                using (var transaction = new TransactionScope(...))
                {
                    invoke(); //invoke original code
                    transaction.Complete();
                }
            });
        }
    }
