    public class ControllerActionTransactionInvoker : ApiControllerActionInvoker
    {
        public override async Task<HttpResponseMessage> InvokeActionAsync(HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                HttpResponseMessage result = await base.InvokeActionAsync(actionContext, cancellationToken);
                scope.Complete();
                return result;
            }
        }
    }
