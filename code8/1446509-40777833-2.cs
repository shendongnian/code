    public class TransactionScopeAspect : Aspect
    {
        override protected Advice Advise(Type type, MethodInfo method)
        {
            if (Attribute.IsDefined(method, typeof(TransactionAttribute))
            {
                //define how to rewrite method
                return new Arround(invoke =>
                {
                    using (var transaction = new TransactionScope(...))
                    {
                        invoke(); //invoke original code
                        transaction.Complete();
                    }
                });
            }
            return null; //nothing special if method not tagged with TransactionAttribute.
        }
    }
