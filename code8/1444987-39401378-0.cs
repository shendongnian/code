    private static void RetrieveRequestObject(ref object objRequest, object objBusinessHeader, 
        object objSecurityHeader, object objManifestHeader, object objFormData)
    {
        var serviceInstance = Activator.CreateInstance("AssemblyName",
            "Service" + TaxYear + ".BulkRequestTransmitterRequest")
    
        var serviceInstanceType = serviceInstance.GetType();
    
        var aCABusinessHeaderInfo = serviceInstanceType.GetProperty("ACABusinessHeader");
        var securityInfo = serviceInstanceType.GetProperty("Security");
        var aCATransmitterManifestReqDtlInfo = serviceInstanceType.GetProperty("ACATransmitterManifestReqDtl");
        var aCABulkRequestTransmitterInfo = serviceInstanceType.GetProperty("ACABulkRequestTransmitter");
    
        aCABusinessHeaderInfo.SetValue(serviceInstance, objBusinessHeader, null);
        securityInfo.SetValue(serviceInstance, objSecurityHeader, null);
        aCATransmitterManifestReqDtlInfo.SetValue(serviceInstance, objManifestHeader, null);
        aCABulkRequestTransmitterInfo.SetValue(serviceInstance, objFormData, null);
    }
