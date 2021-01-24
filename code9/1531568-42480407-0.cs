    public class GenericJsonWebHookHandler : WebHookHandler
    {
        public GenericJsonWebHookHandler()
        {
            this.Receiver = "genericjson";
        }
        public override Task ExecuteAsync(string generator, WebHookHandlerContext context)
        {
            var result = false;
            try
            {
                // Get JSON from WebHook
                var data = context.GetDataOrDefault<JObject>();
                if(context.Id != "crcu" && context.Id != "cror")
                    return Task.FromResult(true);
                if (context.Id == "crcu")
                {
                    result = WoocommerceCRMIntegrations.Entities.Contact.CreateContactInCRM(data);
                }
                else if (context.Id == "cror")
                {
                    result = WoocommerceCRMIntegrations.Entities.Order.CreateOrderInCRM(data);
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return Task.FromResult(result);
        }
    }
