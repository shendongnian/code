    String connectionString = @"AuthType=AD;Url=http://xyz/CRO; Domain=DEVDOMAIN; Username=user01; Password=12345";
    CrmServiceClient conn = new CrmServiceClient(connectionString);
    IOrganizationService orgService = conn.OrganizationWebProxyClient != null ? (IOrganizationService)conn.OrganizationWebProxyClient : (IOrganizationService)conn.OrganizationServiceProxy;
    QueryExpression qExpr = new QueryExpression("pluginassembly") { ColumnSet = new ColumnSet(new string[] { "pluginassemblyid", "content" }) };
    qExpr.Criteria.AddCondition("name", ConditionOperator.Equal, "YourAssemblyName");
    EntityCollection entColl = orgService.RetrieveMultiple(qExpr);
    Byte[] data = Convert.FromBase64String((String)entColl[0]["content"]);
