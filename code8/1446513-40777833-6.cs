    public class TransactionScopeAspect : Aspect
    {
        override protected IEnumerable<Advice<T>> Advise(MethodInfo method)
        {
            if (Attribute.IsDefined(method, typeof(TransactionAttribute))
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
    }
