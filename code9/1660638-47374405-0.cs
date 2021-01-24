    public class StartUp {
    
    	public void Configuration(IAppBuilder app) {
    		var builder = new ContainerBuilder();
    
    		//Note: Initialize / register the Metadata Service that can bring the tenant details from the corresponding store
    		builder.RegisterType<TenantMetadataService>().As<ITenantMetadataService>();
    
    		//Note: This helps you in accessing the TenantMetadata from any constructor going forward after the below registry
    		builder.Register(ti => TenantMetadata.GetTenantMetadataFromRequest()).InstancePerRequest();
    
    		//TODO: Register the various services / controllers etc which may require the tenant details here
    	}
    
    }
    
    public class TenantMetadata {
    
    	public Guid TenantId { get;set; }
    	public Uri TenantUrl { get;set; }
    	public string TenantName { get;set; }
    
    	public static TenantMetadata GetTenantMetadataFromRequest() {
    
    		var context = HttpContext.Current;
    
            //TODO: If you have any header like TenantId coming from the request, you can read and use it
    		var tenantIdFromRequestHeader = "";
    
            //TODO: There will be a lazy cache that keeps building the data as new tenant's login or use the application
    		if(TenantCache.Contains(...))return TenantCache[Key];
            
            //TODO: Do a look-up from the above step and then construct the metadata
            var tenantMetadata = metadataSvc.GetTenantMetadata(...);
            //TODO: If the data match does not happen from the Step2, build the cache and then return the value.
            TenantCache.Add(key,tenantMetadata);
            return tenantMetadata;
    	}
    }
