    public class CallContextStrategy : ITenantIdentificationStrategy
    {
        public bool TryIdentifyTenant(out object tenantId)
        {
            var handle = CallContext.LogicalGetData("TenantIdentification" + AppDomain.CurrentDomain.Id) as ObjectHandle;
            var tenantId = handle?.Unwrap() as string;
            return tenantId != null;
        }
    }
