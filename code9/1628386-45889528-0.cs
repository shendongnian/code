    public override string GenerateWsdl(WsdlTemplateBase wsdlTemplate)
    {
        wsdlTemplate.ServiceName = "NotificationService";
        return base.GenerateWsdl(wsdlTemplate);
    }
