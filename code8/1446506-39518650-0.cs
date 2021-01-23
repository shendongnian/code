    using System.Transactions;
    using PostSharp.Aspects;
    using PostSharp.Serialization;
    
    namespace MyProject
    {
        [PSerializable]
        public class Transaction : OnMethodBoundaryAspect
        {
            public Transaction()
            {
    			//Required if the decorated method is async
                ApplyToStateMachine = true;
            }
    
            public override void OnEntry(MethodExecutionArgs args)
            {
    			//TransactionScopeAsyncFlowOption.Enabled => Required if the decorated method is async
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);
                args.MethodExecutionTag = transactionScope;
            }
    
            public override void OnSuccess(MethodExecutionArgs args)
            {
                var transactionScope = (TransactionScope)args.MethodExecutionTag;
                transactionScope.Complete();
            }
    
            public override void OnExit(MethodExecutionArgs args)
            {
                var transactionScope = (TransactionScope)args.MethodExecutionTag;
                transactionScope.Dispose();
            }
        }
    }
