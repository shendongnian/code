    public class TenantIdentityHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var id = request.Headers.GetValues("X-Tenant-ID").FirstOrDefault();
            CallContext.LogicalSetData("TenantIdentification", new ObjectHandle(id));
            return await base.SendAsync(request, cancellationToken);
        }
    }
