    public class TestOnlinePlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            CrmConnection conn = CrmConnection.Parse("Url=https://***.crm4.dynamics.com; Username=***; Password=***;");
            IOrganizationService orgService = new OrganizationService(conn);
            WhoAmIRequest req = new WhoAmIRequest();
            WhoAmIResponse resp = (WhoAmIResponse) orgService.Execute(req);
            throw new InvalidPluginExecutionException($"Remote user ID: {resp.UserId}");
        }
    }
