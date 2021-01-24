    namespace MyLibrary.Activities
    {
        using System;
        using System.Activities;
    
        public sealed class MyActivity : AsyncCodeActivity
        {
            protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
            {
                var delegateToLongOperation = new Func<bool>(this.LongRunningSave);
                context.UserState = delegateToLongOperation;
                return delegateToLongOperation.BeginInvoke(callback, state);
            }
    
            protected override void EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
            {
                var longOperationDelegate = (Func<bool>) context.UserState;
                var longOperationResult = longOperationDelegate.EndInvoke(result);
    
                // Can continue your activity logic here.
            }
    
            private bool LongRunningSave()
            {
                // Logic to perform the save.
                return true;
            }
        }
    }
